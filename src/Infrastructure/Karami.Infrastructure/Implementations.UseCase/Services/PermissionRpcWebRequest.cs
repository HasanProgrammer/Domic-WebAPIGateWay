using Grpc.Core;
using Grpc.Net.Client;
using Karami.Core.Common.ClassConsts;
using Karami.Core.Common.ClassHelpers;
using Karami.Core.Grpc.Permission;
using Karami.Core.Infrastructure.Extensions;
using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.Infrastructure.Extensions;
using Karami.UseCase.PermissionUseCase.Commands.Create;
using Karami.UseCase.PermissionUseCase.Commands.Delete;
using Karami.UseCase.PermissionUseCase.Commands.Update;
using Karami.UseCase.PermissionUseCase.DTOs.ViewModels;
using Karami.UseCase.PermissionUseCase.Queries.ReadAllPaginated;
using Karami.UseCase.PermissionUseCase.Queries.ReadOne;
using Karami.UseCase.RoleUseCase.Contracts.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

using String                       = Karami.Core.Grpc.Permission.String;
using Int32                        = Karami.Core.Grpc.Permission.Int32;
using CreateResponse               = Karami.UseCase.PermissionUseCase.DTOs.GRPCs.Create.CreateResponse;
using CreateResponseBody           = Karami.UseCase.PermissionUseCase.DTOs.GRPCs.Create.CreateResponseBody;
using DeleteResponse               = Karami.UseCase.PermissionUseCase.DTOs.GRPCs.Delete.DeleteResponse;
using DeleteResponseBody           = Karami.UseCase.PermissionUseCase.DTOs.GRPCs.Delete.DeleteResponseBody;
using ReadAllPaginatedResponse     = Karami.UseCase.PermissionUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponse;
using ReadAllPaginatedResponseBody = Karami.UseCase.PermissionUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponseBody;
using ReadOneResponse              = Karami.UseCase.PermissionUseCase.DTOs.GRPCs.ReadOne.ReadOneResponse;
using ReadOneResponseBody          = Karami.UseCase.PermissionUseCase.DTOs.GRPCs.ReadOne.ReadOneResponseBody;
using UpdateResponse               = Karami.UseCase.PermissionUseCase.DTOs.GRPCs.Update.UpdateResponse;
using UpdateResponseBody           = Karami.UseCase.PermissionUseCase.DTOs.GRPCs.Update.UpdateResponseBody;

namespace Karami.Infrastructure.Implementations.UseCase.Services;

public class PermissionRpcWebRequest : IPermissionRpcWebRequest
{
    private readonly IServiceDiscovery    _serviceDiscovery;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IConfiguration       _configuration;
    
    private GrpcChannel _channel;

    public PermissionRpcWebRequest(IConfiguration configuration, IHttpContextAccessor httpContextAccessor,
        IServiceDiscovery serviceDiscovery
    )
    {
        _configuration       = configuration;
        _httpContextAccessor = httpContextAccessor;
        _serviceDiscovery    = serviceDiscovery;
    }

    public async Task<ReadOneResponse> ReadOneAsync(ReadOneQuery request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(cancellationToken);
        
        ReadOneRequest payload = new() {
            TargetId = request.PermissionId != null ? new String { Value = request.PermissionId } : null
        };

        var result = 
            await loadData.client.ReadOneAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ReadOneResponseBody {
                Permission = new PermissionsViewModel {
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
        var loadData = await _loadGrpcChannelAsync(cancellationToken);
        
        ReadAllPaginatedRequest payload = new() {
            PageNumber   = request?.PageNumber   != null ? new Int32 { Value = (int)request.PageNumber }   : null ,
            CountPerPage = request?.CountPerPage != null ? new Int32 { Value = (int)request.CountPerPage } : null
        };

        var result = 
            await loadData.client.ReadAllPaginateAsync(payload, headers: loadData.headers, 
                cancellationToken: cancellationToken
            );
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ReadAllPaginatedResponseBody {
                Permissions = result.Body.Permissions.DeSerialize<PaginatedCollection<PermissionsViewModel>>()
            } 
        };
    }

    public async Task<CreateResponse> CreateAsync(CreateCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(cancellationToken);
        
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
        var loadData = await _loadGrpcChannelAsync(cancellationToken);
        
        UpdateRequest payload = new();
        
        payload.TargetId = request.PermissionId != null ? new String { Value = request.PermissionId } : null;
        payload.RoleId   = request.RoleId       != null ? new String { Value = request.RoleId }       : null;
        payload.Name     = request.Name         != null ? new String { Value = request.Name }         : null;

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
        var loadData = await _loadGrpcChannelAsync(cancellationToken);
        
        DeleteRequest payload = new();

        payload.TargetId = request.PermissionId != null ? new String { Value = request.PermissionId } : null;

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
        _loadGrpcChannelAsync(CancellationToken cancellationToken)
    {
        var targetServiceInstance =
            await _serviceDiscovery.LoadAddressInMemoryAsync(Service.UserService, cancellationToken);
        
        _channel = GrpcChannel.ForAddress(targetServiceInstance, new GrpcChannelOptions().GetAll());

        return (
            new() {
                { Header.Token   , _httpContextAccessor.HttpContext.GetRowToken() },
                { Header.License , _configuration.GetValue<string>("SecretKey") }
            },
            new PermissionService.PermissionServiceClient (_channel)
        );
    }
}