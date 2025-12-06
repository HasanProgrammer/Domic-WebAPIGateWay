using Grpc.Core;
using Grpc.Net.Client;
using Domic.Core.Common.ClassConsts;
using Domic.Core.Common.ClassHelpers;
using Domic.Core.Role.Grpc;
using Domic.Core.Infrastructure.Extensions;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Infrastructure.Extensions;
using Domic.UseCase.RoleUseCase.Commands.Create;
using Domic.UseCase.RoleUseCase.Commands.SoftDelete;
using Domic.UseCase.RoleUseCase.Commands.Update;
using Domic.UseCase.RoleUseCase.Contracts.Interfaces;
using Domic.UseCase.RoleUseCase.DTOs;
using Domic.UseCase.RoleUseCase.Queries.ReadAllPaginated;
using Domic.UseCase.RoleUseCase.Queries.ReadOne;
using Microsoft.AspNetCore.Http;
using String                       = Domic.Core.Role.Grpc.String;
using Int32                        = Domic.Core.Role.Grpc.Int32;
using CreateResponse               = Domic.UseCase.RoleUseCase.DTOs.GRPCs.Create.CreateResponse;
using CreateResponseBody           = Domic.UseCase.RoleUseCase.DTOs.GRPCs.Create.CreateResponseBody;
using DeleteResponse               = Domic.UseCase.RoleUseCase.DTOs.GRPCs.Delete.DeleteResponse;
using DeleteResponseBody           = Domic.UseCase.RoleUseCase.DTOs.GRPCs.Delete.DeleteResponseBody;
using ReadAllPaginatedResponse     = Domic.UseCase.RoleUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponse;
using ReadAllPaginatedResponseBody = Domic.UseCase.RoleUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponseBody;
using ReadOneResponse              = Domic.UseCase.RoleUseCase.DTOs.GRPCs.ReadOne.ReadOneResponse;
using ReadOneResponseBody          = Domic.UseCase.RoleUseCase.DTOs.GRPCs.ReadOne.ReadOneResponseBody;
using UpdateResponse               = Domic.UseCase.RoleUseCase.DTOs.GRPCs.Update.UpdateResponse;
using UpdateResponseBody           = Domic.UseCase.RoleUseCase.DTOs.GRPCs.Update.UpdateResponseBody;

namespace Domic.Infrastructure.Implementations.UseCase.Services;

public class RoleRpcWebRequest : IRoleRpcWebRequest
{
    private readonly IServiceDiscovery         _serviceDiscovery;
    private readonly IExternalDistributedCache _distributedCache;
    private readonly IHttpContextAccessor      _httpContextAccessor;

    private GrpcChannel _channel;

    public RoleRpcWebRequest(IHttpContextAccessor httpContextAccessor,
        IServiceDiscovery serviceDiscovery, IExternalDistributedCache distributedCache
    )
    {
        _httpContextAccessor = httpContextAccessor;
        _serviceDiscovery    = serviceDiscovery;
        _distributedCache    = distributedCache;
    }
    
    public async Task<ReadOneResponse> ReadOneAsync(ReadOneQuery request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(true, cancellationToken);
        
        ReadOneRequest payload = new() {
            TargetId = request.Id != null ? new String { Value = request.Id } : null
        };

        var result = 
            await loadData.client.ReadOneAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);

        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ReadOneResponseBody { Role = result.Body.Role.DeSerialize<RoleDto>() } 
        };
    }

    public async Task<ReadAllPaginatedResponse> ReadAllPaginatedAsync(ReadAllPaginatedQuery request,
        CancellationToken cancellationToken
    )
    {
        var loadData = await _loadGrpcChannelAsync(true, cancellationToken);
        
        ReadAllPaginatedRequest payload = new() {
            PageNumber   = request.PageNumber   != null ? new Int32 { Value = (int)request.PageNumber }   : null ,
            CountPerPage = request.CountPerPage != null ? new Int32 { Value = (int)request.CountPerPage } : null
        };
        
        payload.Sort       = new Int32 { Value = request.Sort };
        payload.SearchText = !string.IsNullOrEmpty(request.SearchText) ? new String { Value = request.SearchText } : null;

        var result = 
            await loadData.client.ReadAllPaginatedAsync(payload, headers: loadData.headers, 
                cancellationToken: cancellationToken
            );
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ReadAllPaginatedResponseBody { Roles = result.Body.Roles.DeSerialize<PaginatedCollection<RoleDto>>() } 
        };
    }

    public async Task<CreateResponse> CreateAsync(CreateCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        CreateRequest payload = new();

        payload.Name = request.Name != null ? new String { Value = request.Name } : null;
        
        var result = 
            await loadData.client.CreateAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new CreateResponseBody { RoleId = result.Body.RoleId } 
        };
    }

    public async Task<UpdateResponse> UpdateAsync(UpdateCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        UpdateRequest payload = new();
        
        payload.TargetId = request.Id != null ? new String { Value = request.Id } : null;
        payload.Name     = request.Name   != null ? new String { Value = request.Name }   : null;
        
        var result = 
            await loadData.client.UpdateAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new UpdateResponseBody { RoleId = result.Body.RoleId } 
        };
    }

    public async Task<DeleteResponse> DeleteAsync(DeleteCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        var payload = new DeleteRequest {
            TargetId = request.Id != null ? new String { Value = request.Id } : null
        };

        var result = 
            await loadData.client.DeleteAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new DeleteResponseBody { RoleId = result.Body.RoleId } 
        };
    }

    public void Dispose()
    {
        _channel.Dispose();
    }
    
    /*---------------------------------------------------------------*/

    private async Task<(Metadata headers, RoleService.RoleServiceClient client)>
        _loadGrpcChannelAsync(bool isIdempotent, CancellationToken cancellationToken)
    {
        var targetServiceInstanceTask = 
            _serviceDiscovery.LoadAddressInMemoryAsync(Service.UserService, cancellationToken);
        
        var secretKeyTask = _distributedCache.GetCacheValueAsync("SecretKey", cancellationToken);

        await Task.WhenAll(targetServiceInstanceTask, secretKeyTask);
        
        _channel = GrpcChannel.ForAddress(await targetServiceInstanceTask, new GrpcChannelOptions().GetAll());

        var token = _httpContextAccessor.HttpContext.GetRowToken();

        var metaData = new Metadata {
            { Header.License , await secretKeyTask }
        };
        
        if(!string.IsNullOrEmpty(token))
            metaData.Add(Header.Token, token);
        
        if(isIdempotent == false)
            metaData.Add(Header.IdempotentKey, Guid.NewGuid().ToString());
        
        return ( metaData, new RoleService.RoleServiceClient(_channel) );
    }
}