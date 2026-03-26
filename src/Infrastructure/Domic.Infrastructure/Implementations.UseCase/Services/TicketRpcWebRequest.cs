using Grpc.Core;
using Grpc.Net.Client;
using Domic.Core.Common.ClassConsts;
using Domic.Core.Infrastructure.Extensions;
using Domic.Core.Ticket.Grpc;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Infrastructure.Extensions;
using Domic.UseCase.TicketUseCase.Contracts.Interfaces;
using Domic.UseCase.TicketUseCase.Commands.Update;
using Domic.UseCase.TicketUseCase.Commands.Create;
using Domic.UseCase.TicketUseCase.Commands.CreateComment;
using Microsoft.AspNetCore.Http;

using String                    = Domic.Core.Ticket.Grpc.String;
using Int32                     = Domic.Core.Ticket.Grpc.Int32;
using CreateResponse            = Domic.UseCase.TicketUseCase.DTOs.GRPCs.Create.CreateResponse;
using CreateResponseBody        = Domic.UseCase.TicketUseCase.DTOs.GRPCs.Create.CreateResponseBody;
using UpdateResponse            = Domic.UseCase.TicketUseCase.DTOs.GRPCs.Update.UpdateResponse;
using UpdateResponseBody        = Domic.UseCase.TicketUseCase.DTOs.GRPCs.Update.UpdateResponseBody;
using CheckExistRequest         = Domic.Core.Ticket.Grpc.CheckExistRequest;
using CreateCommentResponse     = Domic.UseCase.TicketUseCase.DTOs.GRPCs.CreateComment.CreateCommentResponse;
using CreateCommentResponseBody = Domic.UseCase.TicketUseCase.DTOs.GRPCs.CreateComment.CreateCommentResponseBody;
using CreateRequest             = Domic.Core.Ticket.Grpc.CreateRequest;
using UpdateRequest             = Domic.Core.Ticket.Grpc.UpdateRequest;

namespace Domic.Infrastructure.Implementations.UseCase.Services;

public class TicketRpcWebRequest(
    IServiceDiscovery serviceDiscovery, IHttpContextAccessor httpContextAccessor,
    IExternalDistributedCache distributedCache
) : ITicketRpcWebRequest
{
    private GrpcChannel _channel;

    public async Task<bool> CheckExistAsync(string id, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(true, cancellationToken);
        
        CheckExistRequest payload = new() { TicketId = !string.IsNullOrEmpty(id) ? new String { Value = id } : null };

        var result =
            await loadData.client.CheckExistAsync(payload, headers: loadData.headers, 
                cancellationToken: cancellationToken
            );

        return result.Result;
    }

    public async Task<CreateResponse> CreateAsync(CreateCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        CreateRequest payload = new();
        
        payload.CategoryId  = request.CategoryId  != null ? new String { Value = request.CategoryId }   : null;
        payload.Title       = request.Title       != null ? new String { Value = request.Title }        : null;
        payload.Description = request.Description != null ? new String { Value = request.Description }  : null;
        payload.Priority    = request.Priority    != null ? new Int32 { Value = (int)request.Priority } : null;
        payload.Status      = request.Status      != null ? new Int32  { Value = (int)request.Status }  : null;
        
        var result =
            await loadData.client.CreateAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new CreateResponseBody { TicketId = result.Body.TicketId }
        };
    }

    public async Task<CreateCommentResponse> CreateCommentAsync(CreateCommentCommand request, 
        CancellationToken cancellationToken
    )
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        CreateCommentRequest payload = new();
        
        payload.TicketId = !string.IsNullOrEmpty(request.TicketId) ? new String { Value = request.TicketId } : null;
        payload.Comment  = !string.IsNullOrEmpty(request.Comment)  ? new String { Value = request.Comment }  : null;
        
        var result =
            await loadData.client.CreateCommentAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new CreateCommentResponseBody { TicketCommentId = result.Body.TicketCommentId }
        };
    }

    public async Task<UpdateResponse> UpdateAsync(UpdateCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        UpdateRequest payload = new();

        payload.TicketId    = request.Id          != null ? new String { Value = request.Id }           : null;
        payload.CategoryId  = request.CategoryId  != null ? new String { Value = request.CategoryId }   : null;
        payload.Title       = request.Title       != null ? new String { Value = request.Title }        : null;
        payload.Description = request.Description != null ? new String { Value = request.Description }  : null;
        payload.Priority    = request.Priority    != null ? new Int32 { Value = (int)request.Priority } : null;
        payload.Status      = request.Status      != null ? new Int32  { Value = (int)request.Status }  : null;
        
        var result =
            await loadData.client.UpdateAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new UpdateResponseBody { TicketId = result.Body.TicketId }
        };
    }

    public void Dispose() => _channel.Dispose();
    
    /*---------------------------------------------------------------*/

    private async Task<(Metadata headers, TicketService.TicketServiceClient client)> 
        _loadGrpcChannelAsync(bool isIdempotent, CancellationToken cancellationToken)
    {
        var targetServiceInstanceTask =
            serviceDiscovery.LoadAddressInMemoryAsync(serviceName: "TicketService", cancellationToken);
        
        var secretKeyTask = distributedCache.GetCacheValueAsync("SecretKey", cancellationToken);

        await Task.WhenAll(targetServiceInstanceTask, secretKeyTask);
        
        _channel = GrpcChannel.ForAddress(await targetServiceInstanceTask, new GrpcChannelOptions().GetAll());
        
        var metaData = new Metadata {
            { Header.Token   , httpContextAccessor.HttpContext.GetRowToken() } ,
            { Header.License , await secretKeyTask }
        };
        
        if(isIdempotent == false)
            metaData.Add(Header.IdempotentKey, Guid.NewGuid().ToString());
        
        return ( metaData, new TicketService.TicketServiceClient(_channel) );
    }
}