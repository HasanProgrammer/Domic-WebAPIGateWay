using Grpc.Core;
using Grpc.Net.Client;
using Domic.Core.Common.ClassConsts;
using Domic.Core.Common.ClassHelpers;
using Domic.Core.Infrastructure.Extensions;
using Domic.Core.Ticket.Grpc;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Infrastructure.Extensions;
using Domic.UseCase.TicketUseCase.Contracts.Interfaces;
using Domic.UseCase.TicketUseCase.Commands.Active;
using Domic.UseCase.TicketUseCase.Commands.Update;
using Domic.UseCase.TicketUseCase.Commands.Create;
using Domic.UseCase.TicketUseCase.Commands.InActive;
using Domic.UseCase.TicketUseCase.DTOs;
using Domic.UseCase.TicketUseCase.Queries.ReadAllPaginated;
using Domic.UseCase.TicketUseCase.Queries.ReadOne;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using String                       = Domic.Core.Ticket.Grpc.String;
using Int32                        = Domic.Core.Ticket.Grpc.Int32;
using ActiveRequest                = Domic.Core.Ticket.Grpc.ActiveRequest;
using ReadOneResponse              = Domic.UseCase.TicketUseCase.DTOs.GRPCs.ReadOne.ReadOneResponse;
using ReadOneResponseBody          = Domic.UseCase.TicketUseCase.DTOs.GRPCs.ReadOne.ReadOneResponseBody;
using CreateResponse               = Domic.UseCase.TicketUseCase.DTOs.GRPCs.Create.CreateResponse;
using CreateResponseBody           = Domic.UseCase.TicketUseCase.DTOs.GRPCs.Create.CreateResponseBody;
using ReadAllPaginatedResponse     = Domic.UseCase.TicketUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponse;
using ReadAllPaginatedResponseBody = Domic.UseCase.TicketUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponseBody;
using UpdateResponse               = Domic.UseCase.TicketUseCase.DTOs.GRPCs.Update.UpdateResponse;
using UpdateResponseBody           = Domic.UseCase.TicketUseCase.DTOs.GRPCs.Update.UpdateResponseBody;
using ActiveResponse               = Domic.UseCase.TicketUseCase.DTOs.GRPCs.Active.ActiveResponse;
using ActiveResponseBody           = Domic.UseCase.TicketUseCase.DTOs.GRPCs.Active.ActiveResponseBody;
using CheckExistRequest            = Domic.Core.Ticket.Grpc.CheckExistRequest;
using CreateRequest                = Domic.Core.Ticket.Grpc.CreateRequest;
using InActiveRequest              = Domic.Core.Ticket.Grpc.InActiveRequest;
using InActiveResponse             = Domic.UseCase.TicketUseCase.DTOs.GRPCs.InActive.InActiveResponse;
using InActiveResponseBody         = Domic.UseCase.TicketUseCase.DTOs.GRPCs.InActive.InActiveResponseBody;
using ReadAllPaginatedRequest      = Domic.Core.Ticket.Grpc.ReadAllPaginatedRequest;
using ReadOneRequest               = Domic.Core.Ticket.Grpc.ReadOneRequest;
using UpdateRequest                = Domic.Core.Ticket.Grpc.UpdateRequest;

namespace Domic.Infrastructure.Implementations.UseCase.Services;

public class TicketRpcWebRequest(
    IServiceDiscovery serviceDiscovery, IHttpContextAccessor httpContextAccessor, IConfiguration configuration
) : ITicketRpcWebRequest
{
    private GrpcChannel _channel;

    public async Task<bool> CheckExistAsync(string id, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelForTicketServiceAsync(cancellationToken);
        
        CheckExistRequest payload = new() { TicketId = !string.IsNullOrEmpty(id) ? new String { Value = id } : null };

        var result =
            await loadData.client.CheckExistAsync(payload, headers: loadData.headers, 
                cancellationToken: cancellationToken
            );

        return result.Result;
    }

    public async Task<ReadOneResponse> ReadOneAsync(ReadOneQuery request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelForTicketServiceAsync(cancellationToken);
        
        ReadOneRequest payload = new() {
            TicketId = request.TicketId != null ? new String { Value = request.TicketId } : null
        };

        var result =
            await loadData.client.ReadOneAsync(payload, headers: loadData.headers, 
                cancellationToken: cancellationToken
            );

        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ReadOneResponseBody { Ticket = result.Body.Ticket.DeSerialize<TicketsDto>() } 
        };
    }

    public async Task<ReadAllPaginatedResponse> ReadAllPaginatedAsync(ReadAllPaginatedQuery request,
        CancellationToken cancellationToken
    )
    {
        var loadData = await _loadGrpcChannelForTicketServiceAsync(cancellationToken);
        
        ReadAllPaginatedRequest payload = new() {
            PageNumber   = request.PageNumber   != null ? new Int32 { Value = (int)request.PageNumber }   : null ,
            CountPerPage = request.CountPerPage != null ? new Int32 { Value = (int)request.CountPerPage } : null
        };
        
        var result =
            await loadData.client.ReadAllPaginateAsync(payload, headers: loadData.headers, 
                cancellationToken: cancellationToken
            );
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ReadAllPaginatedResponseBody {
                Tickets = result.Body.Tickets.DeSerialize<PaginatedCollection<TicketsDto>>()
            }
        };
    }

    public async Task<CreateResponse> CreateAsync(CreateCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelForTicketServiceAsync(cancellationToken);
        
        CreateRequest payload = new();
        
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

    public async Task<UpdateResponse> UpdateAsync(UpdateCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelForTicketServiceAsync(cancellationToken);
        
        UpdateRequest payload = new();

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

    public async Task<ActiveResponse> ActiveAsync(ActiveCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelForTicketServiceAsync(cancellationToken);
        
        ActiveRequest payload = new();

        payload.TicketId = request.TicketId is not null ? new String { Value = request.TicketId } : null;

        var result = 
            await loadData.client.ActiveAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);

        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ActiveResponseBody { TicketId = result.Body.TicketId } 
        };
    }

    public async Task<InActiveResponse> InActiveAsync(InActiveCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelForTicketServiceAsync(cancellationToken);
        
        InActiveRequest payload = new();

        payload.TicketId = request.TicketId is not null ? new String { Value = request.TicketId } : null;

        var result = 
            await loadData.client.InActiveAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);

        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new InActiveResponseBody { TicketId = result.Body.TicketId } 
        };
    }

    public void Dispose() => _channel.Dispose();
    
    /*---------------------------------------------------------------*/

    private async Task<(Metadata headers, TicketService.TicketServiceClient client)> 
        _loadGrpcChannelForTicketServiceAsync(CancellationToken cancellationToken)
    {
        var targetServiceInstance =
            await serviceDiscovery.LoadAddressInMemoryAsync("TicketService", cancellationToken);
        
        _channel = GrpcChannel.ForAddress(targetServiceInstance, new GrpcChannelOptions().GetAll());
        
        //Todo : ( Tech Debt ) => Shoud be ignore ( CheckExists ) action!
        
        return (
            new() {
                { Header.Token         , httpContextAccessor.HttpContext.GetRowToken() } ,
                { Header.License       , configuration.GetValue<string>("SecretKey") }   ,
                { Header.IdempotentKey , Guid.NewGuid().ToString() }
            },
            new TicketService.TicketServiceClient(_channel)
        );
    }
}