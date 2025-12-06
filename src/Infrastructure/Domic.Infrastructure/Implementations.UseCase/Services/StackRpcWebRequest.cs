using Grpc.Core;
using Grpc.Net.Client;
using Domic.Core.Common.ClassConsts;
using Domic.Core.Common.ClassHelpers;
using Domic.Core.Infrastructure.Extensions;
using Domic.Core.Stack.Grpc;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Infrastructure.Extensions;
using Domic.UseCase.StackUseCase.Commands.Active;
using Domic.UseCase.StackUseCase.Commands.Update;
using Domic.UseCase.StackUseCase.Commands.Create;
using Domic.UseCase.StackUseCase.Commands.InActive;
using Domic.UseCase.StackUseCase.Queries.ReadAllPaginated;
using Domic.UseCase.StackUseCase.Queries.ReadOne;
using Domic.UseCase.StackUseCase.Contracts.Interfaces;
using Domic.UseCase.StackUseCase.DTOs;
using Microsoft.AspNetCore.Http;

using String                           = Domic.Core.Stack.Grpc.String;
using Int32                            = Domic.Core.Stack.Grpc.Int32;
using ActiveRequest                    = Domic.Core.Stack.Grpc.ActiveRequest;
using CheckExistRequest                = Domic.Core.Stack.Grpc.CheckExistRequest;
using CreateRequest                    = Domic.Core.Stack.Grpc.CreateRequest;
using InActiveRequest                  = Domic.Core.Stack.Grpc.InActiveRequest;
using ReadAllPaginatedRequest          = Domic.Core.Stack.Grpc.ReadAllPaginatedRequest;
using ReadOneRequest                   = Domic.Core.Stack.Grpc.ReadOneRequest;
using UpdateRequest                    = Domic.Core.Stack.Grpc.UpdateRequest;
using ReadOneResponse                  = Domic.UseCase.StackUseCase.DTOs.GRPCs.ReadOne.ReadOneResponse;
using ReadOneResponseBody              = Domic.UseCase.StackUseCase.DTOs.GRPCs.ReadOne.ReadOneResponseBody;
using CreateResponse                   = Domic.UseCase.StackUseCase.DTOs.GRPCs.Create.CreateResponse;
using CreateResponseBody               = Domic.UseCase.StackUseCase.DTOs.GRPCs.Create.CreateResponseBody;
using ReadAllPaginatedResponse         = Domic.UseCase.StackUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponse;
using ReadAllPaginatedResponseBody     = Domic.UseCase.StackUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponseBody;
using UpdateResponse                   = Domic.UseCase.StackUseCase.DTOs.GRPCs.Update.UpdateResponse;
using UpdateResponseBody               = Domic.UseCase.StackUseCase.DTOs.GRPCs.Update.UpdateResponseBody;
using ActiveResponse                   = Domic.UseCase.StackUseCase.DTOs.GRPCs.Active.ActiveResponse;
using ActiveResponseBody               = Domic.UseCase.StackUseCase.DTOs.GRPCs.Active.ActiveResponseBody;
using DeleteResponse                   = Domic.UseCase.StackUseCase.DTOs.GRPCs.Update.DeleteResponse;
using DeleteResponseBody               = Domic.UseCase.StackUseCase.DTOs.GRPCs.Update.DeleteResponseBody;
using InActiveResponse                 = Domic.UseCase.StackUseCase.DTOs.GRPCs.InActive.InActiveResponse;
using InActiveResponseBody             = Domic.UseCase.StackUseCase.DTOs.GRPCs.InActive.InActiveResponseBody;

namespace Domic.Infrastructure.Implementations.UseCase.Services;

public class StackRpcWebRequest(
    IServiceDiscovery serviceDiscovery, IHttpContextAccessor httpContextAccessor,
    IExternalDistributedCache distributedCache
) : IStackRpcWebRequest
{
    private GrpcChannel _channel;

    public async Task<bool> CheckExistAsync(string id, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(true, cancellationToken);
        
        CheckExistRequest payload = new() { Id = !string.IsNullOrEmpty(id) ? new String { Value = id } : null };

        var result =
            await loadData.client.CheckExistAsync(payload, headers: loadData.headers, 
                cancellationToken: cancellationToken
            );

        return result.Result;
    }

    public async Task<ReadOneResponse> ReadOneAsync(ReadOneQuery request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(true, cancellationToken);
        
        ReadOneRequest payload = new() {
            Id = request.Id != null ? new String { Value = request.Id } : null
        };

        var result =
            await loadData.client.ReadOneAsync(payload, headers: loadData.headers, 
                cancellationToken: cancellationToken
            );

        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ReadOneResponseBody { Stack = result.Body.Stack.DeSerialize<StackDto>() } 
        };
    }

    /*public async Task<ReadAllPaginatedResponse> ReadAllPaginatedAsync(ReadAllPaginatedQuery request,
        CancellationToken cancellationToken
    )
    {
        var loadData = await _loadGrpcChannelAsync(true, cancellationToken);
        
        ReadAllPaginatedRequest payload = new() {
            PageNumber   = request.PageNumber   != null ? new Int32 { Value = (int)request.PageNumber }   : null ,
            CountPerPage = request.CountPerPage != null ? new Int32 { Value = (int)request.CountPerPage } : null
        };
        
        var result =
            await loadData.client.ReadAllPaginatedAsync(payload, headers: loadData.headers, 
                cancellationToken: cancellationToken
            );
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ReadAllPaginatedResponseBody {
                Seasons = result.Body.Seasons.DeSerialize<PaginatedCollection<SeasonDto>>()
            }
        };
    }*/

    public async Task<CreateResponse> CreateAsync(CreateCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        CreateRequest payload = new();

        payload.Name = !string.IsNullOrEmpty(request.Name) ? new String { Value = request.Name } : null;
        
        var result =
            await loadData.client.CreateAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new CreateResponseBody { Id = result.Body.StackId }
        };
    }

    public async Task<UpdateResponse> UpdateAsync(UpdateCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        UpdateRequest payload = new();

        payload.Id   = !string.IsNullOrEmpty(request.Id)   ? new String { Value = request.Id }   : null;
        payload.Name = !string.IsNullOrEmpty(request.Name) ? new String { Value = request.Name } : null;
        
        var result =
            await loadData.client.UpdateAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new UpdateResponseBody { Id = result.Body.StackId }
        };
    }

    public async Task<DeleteResponse> DeleteAsync(DeleteCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        DeleteRequest payload = new();

        payload.Id = !string.IsNullOrEmpty(request.Id ) ? new String { Value = request.Id } : null;

        var result =
            await loadData.client.DeleteAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);

        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new DeleteResponseBody { Id = result.Body.StackId } 
        };
    }

    public async Task<ActiveResponse> ActiveAsync(ActiveCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        ActiveRequest payload = new();

        payload.Id = !string.IsNullOrEmpty(request.Id) ? new String { Value = request.Id } : null;

        var result =
            await loadData.client.ActiveAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);

        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ActiveResponseBody { Id = result.Body.StackId } 
        };
    }

    public async Task<InActiveResponse> InActiveAsync(InActiveCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        InActiveRequest payload = new();

        payload.Id = !string.IsNullOrEmpty(request.Id) ? new String { Value = request.Id } : null;

        var result =
            await loadData.client.InActiveAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);

        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new InActiveResponseBody { Id = result.Body.StackId } 
        };
    }

    public void Dispose() => _channel.Dispose();
    
    /*---------------------------------------------------------------*/

    private async Task<(Metadata headers, StackService.StackServiceClient client)> 
        _loadGrpcChannelAsync(bool isIdempotent, CancellationToken cancellationToken)
    {
        var targetServiceInstanceTask =
            serviceDiscovery.LoadAddressInMemoryAsync("HumanResourceService", cancellationToken);
        
        var secretKeyTask = distributedCache.GetCacheValueAsync("SecretKey", cancellationToken);

        await Task.WhenAll(targetServiceInstanceTask, secretKeyTask);
        
        _channel = GrpcChannel.ForAddress(await targetServiceInstanceTask, new GrpcChannelOptions().GetAll());
        
        var metaData = new Metadata {
            { Header.Token   , httpContextAccessor.HttpContext.GetRowToken() } ,
            { Header.License , await secretKeyTask }
        };
        
        if(!isIdempotent)
            metaData.Add(Header.IdempotentKey, Guid.NewGuid().ToString());
        
        return ( metaData, new StackService.StackServiceClient(_channel) );
    }
}