﻿using Grpc.Core;
using Grpc.Net.Client;
using Domic.Core.Common.ClassConsts;
using Domic.Core.Common.ClassHelpers;
using Domic.Core.Permission.Grpc;
using Domic.Core.Infrastructure.Extensions;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Infrastructure.Extensions;
using Domic.UseCase.PermissionUseCase.Commands.Create;
using Domic.UseCase.PermissionUseCase.Commands.Delete;
using Domic.UseCase.PermissionUseCase.Commands.Update;
using Domic.UseCase.PermissionUseCase.DTOs;
using Domic.UseCase.PermissionUseCase.Queries.ReadAllBasedOnRolesPaginated;
using Domic.UseCase.PermissionUseCase.Queries.ReadAllPaginated;
using Domic.UseCase.PermissionUseCase.Queries.ReadOne;
using Domic.UseCase.RoleUseCase.Contracts.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

using String                       = Domic.Core.Permission.Grpc.String;
using Int32                        = Domic.Core.Permission.Grpc.Int32;
using CreateResponse               = Domic.UseCase.PermissionUseCase.DTOs.GRPCs.Create.CreateResponse;
using CreateResponseBody           = Domic.UseCase.PermissionUseCase.DTOs.GRPCs.Create.CreateResponseBody;
using DeleteResponse               = Domic.UseCase.PermissionUseCase.DTOs.GRPCs.Delete.DeleteResponse;
using DeleteResponseBody           = Domic.UseCase.PermissionUseCase.DTOs.GRPCs.Delete.DeleteResponseBody;
using ReadAllBasedOnRolesPaginatedResponse = Domic.UseCase.PermissionUseCase.DTOs.GRPCs.ReadAllBasedOnRolesPaginated.ReadAllBasedOnRolesPaginatedResponse;
using ReadAllBasedOnRolesPaginatedResponseBody = Domic.UseCase.PermissionUseCase.DTOs.GRPCs.ReadAllBasedOnRolesPaginated.ReadAllBasedOnRolesPaginatedResponseBody;
using ReadAllPaginatedResponse     = Domic.UseCase.PermissionUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponse;
using ReadAllPaginatedResponseBody = Domic.UseCase.PermissionUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponseBody;
using ReadOneResponse              = Domic.UseCase.PermissionUseCase.DTOs.GRPCs.ReadOne.ReadOneResponse;
using ReadOneResponseBody          = Domic.UseCase.PermissionUseCase.DTOs.GRPCs.ReadOne.ReadOneResponseBody;
using UpdateResponse               = Domic.UseCase.PermissionUseCase.DTOs.GRPCs.Update.UpdateResponse;
using UpdateResponseBody           = Domic.UseCase.PermissionUseCase.DTOs.GRPCs.Update.UpdateResponseBody;

namespace Domic.Infrastructure.Implementations.UseCase.Services;

public class PermissionRpcWebRequest : IPermissionRpcWebRequest
{
    private readonly IServiceDiscovery         _serviceDiscovery;
    private readonly IExternalDistributedCache _distributedCache;
    private readonly IHttpContextAccessor      _httpContextAccessor;
    private readonly IConfiguration            _configuration;
    
    private GrpcChannel _channel;

    public PermissionRpcWebRequest(IConfiguration configuration, IHttpContextAccessor httpContextAccessor,
        IServiceDiscovery serviceDiscovery, IExternalDistributedCache distributedCache
    )
    {
        _configuration       = configuration;
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
            Body    = new ReadOneResponseBody {
                Permission = new PermissionDto {
                    Id       = result.Body.Permission.Id     ,
                    Name     = result.Body.Permission.Name   ,
                    RoleId   = result.Body.Permission.RoleId ,
                    RoleName = result.Body.Permission.RoleName
                }
            } 
        };
    }

    public async Task<ReadAllPaginatedResponse> ReadAllPaginatedAsync(ReadAllPaginatedQuery request,
        CancellationToken cancellationToken
    )
    {
        var loadData = await _loadGrpcChannelAsync(true, cancellationToken);
        
        ReadAllPaginatedRequest payload = new() {
            PageNumber   = request?.PageNumber   != null ? new Int32 { Value = (int)request.PageNumber }   : null ,
            CountPerPage = request?.CountPerPage != null ? new Int32 { Value = (int)request.CountPerPage } : null
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
            Body    = new ReadAllPaginatedResponseBody {
                Permissions = result.Body.Permissions.DeSerialize<PaginatedCollection<PermissionDto>>()
            } 
        };
    }

    public async Task<ReadAllBasedOnRolesPaginatedResponse> ReadAllBasedOnRolesPaginatedAsync(
        ReadAllBasedOnRolesPaginatedQuery request, CancellationToken cancellationToken
    )
    {
        var loadData = await _loadGrpcChannelAsync(true, cancellationToken);
        
        ReadAllBasedOnRolesPaginatedRequest payload = new() {
            PageNumber   = request?.PageNumber   != null ? new Int32 { Value = (int)request.PageNumber }   : null ,
            CountPerPage = request?.CountPerPage != null ? new Int32 { Value = (int)request.CountPerPage } : null
        };
        
        payload.Roles = !string.IsNullOrEmpty(request.Roles) ? new String { Value = request.Roles } : null;

        var result =
            await loadData.client.ReadAllBasedOnRolesPaginatedAsync(payload, headers: loadData.headers, 
                cancellationToken: cancellationToken
            );
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ReadAllBasedOnRolesPaginatedResponseBody {
                Permissions = result.Body.Permissions.DeSerialize<PaginatedCollection<PermissionDto>>()
            }
        };
    }

    public async Task<CreateResponse> CreateAsync(CreateCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        CreateRequest payload = new();
        
        payload.Name   = request.Name   != null ? new String { Value = request.Name }   : null;
        payload.RoleId = request.RoleId != null ? new String { Value = request.RoleId } : null;

        var result = 
            await loadData.client.CreateAsync(payload, headers: loadData.headers, 
                cancellationToken: cancellationToken
            );
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new CreateResponseBody { PermissionId = result.Body.PermissionId } 
        };
    }

    public async Task<UpdateResponse> UpdateAsync(UpdateCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        UpdateRequest payload = new();
        
        payload.TargetId = request.Id     != null ? new String { Value = request.Id }     : null;
        payload.RoleId   = request.RoleId != null ? new String { Value = request.RoleId } : null;
        payload.Name     = request.Name   != null ? new String { Value = request.Name }   : null;

        var result = 
            await loadData.client.UpdateAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new UpdateResponseBody { PermissionId = result.Body.PermissionId } 
        };
    }

    public async Task<DeleteResponse> DeleteAsync(DeleteCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        DeleteRequest payload = new();

        payload.TargetId = request.Id != null ? new String { Value = request.Id } : null;

        var result = 
            await loadData.client.DeleteAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new DeleteResponseBody { PermissionId = result.Body.PermissionId } 
        };
    }

    public void Dispose()
    {
        _channel.Dispose();
    }
    
    /*---------------------------------------------------------------*/

    private async Task<(Metadata headers, PermissionService.PermissionServiceClient client)> 
        _loadGrpcChannelAsync(bool isIdempotent, CancellationToken cancellationToken)
    {
        var targetServiceInstanceTask = 
            _serviceDiscovery.LoadAddressInMemoryAsync(Service.UserService, cancellationToken);
        
        var secretKeyTask = _distributedCache.GetCacheValueAsync("SecretKey", cancellationToken);

        await Task.WhenAll(targetServiceInstanceTask, secretKeyTask);
        
        _channel = GrpcChannel.ForAddress(await targetServiceInstanceTask, new GrpcChannelOptions().GetAll());

        var metaData = new Metadata {
            { Header.Token   , _httpContextAccessor.HttpContext.GetRowToken() } ,
            { Header.License , await secretKeyTask }
        };
        
        if(isIdempotent == false)
            metaData.Add(Header.IdempotentKey, Guid.NewGuid().ToString());
        
        return ( metaData, new PermissionService.PermissionServiceClient (_channel) );
    }
}