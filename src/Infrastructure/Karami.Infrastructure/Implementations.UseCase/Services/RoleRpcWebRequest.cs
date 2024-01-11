using Grpc.Core;
using Grpc.Net.Client;
using Karami.Core.Common.ClassConsts;
using Karami.Core.Common.ClassHelpers;
using Karami.Core.Grpc.Role;
using Karami.Core.Infrastructure.Extensions;
using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.Infrastructure.Extensions;
using Karami.UseCase.RoleUseCase.Commands.Create;
using Karami.UseCase.RoleUseCase.Commands.SoftDelete;
using Karami.UseCase.RoleUseCase.Commands.Update;
using Karami.UseCase.RoleUseCase.Contracts.Interfaces;
using Karami.UseCase.RoleUseCase.DTOs.ViewModels;
using Karami.UseCase.RoleUseCase.Queries.ReadAllPaginated;
using Karami.UseCase.RoleUseCase.Queries.ReadOne;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

using String                       = Karami.Core.Grpc.Role.String;
using Int32                        = Karami.Core.Grpc.Role.Int32;
using CreateResponse               = Karami.UseCase.RoleUseCase.DTOs.GRPCs.Create.CreateResponse;
using CreateResponseBody           = Karami.UseCase.RoleUseCase.DTOs.GRPCs.Create.CreateResponseBody;
using DeleteResponse               = Karami.UseCase.RoleUseCase.DTOs.GRPCs.Delete.DeleteResponse;
using DeleteResponseBody           = Karami.UseCase.RoleUseCase.DTOs.GRPCs.Delete.DeleteResponseBody;
using ReadAllPaginatedResponse     = Karami.UseCase.RoleUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponse;
using ReadAllPaginatedResponseBody = Karami.UseCase.RoleUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponseBody;
using ReadOneResponse              = Karami.UseCase.RoleUseCase.DTOs.GRPCs.ReadOne.ReadOneResponse;
using ReadOneResponseBody          = Karami.UseCase.RoleUseCase.DTOs.GRPCs.ReadOne.ReadOneResponseBody;
using UpdateResponse               = Karami.UseCase.RoleUseCase.DTOs.GRPCs.Update.UpdateResponse;
using UpdateResponseBody           = Karami.UseCase.RoleUseCase.DTOs.GRPCs.Update.UpdateResponseBody;

namespace Karami.Infrastructure.Implementations.UseCase.Services;

public class RoleRpcWebRequest : IRoleRpcWebRequest
{
    private readonly IServiceDiscovery    _serviceDiscovery;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IConfiguration       _configuration;
    
    private GrpcChannel _channel;

    public RoleRpcWebRequest(IConfiguration configuration, IHttpContextAccessor httpContextAccessor,
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
            TargetId = request.RoleId != null ? new String { Value = request.RoleId } : null
        };

        var result = 
            await loadData.client.ReadOneAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);

        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ReadOneResponseBody { Role = result.Body.Role.DeSerialize<RolesViewModel>() } 
        };
    }

    public async Task<ReadAllPaginatedResponse> ReadAllPaginatedAsync(ReadAllPaginatedQuery request,
        CancellationToken cancellationToken
    )
    {
        var loadData = await _loadGrpcChannelAsync(cancellationToken);
        
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
            Body    = new ReadAllPaginatedResponseBody { Roles = result.Body.Roles.DeSerialize<PaginatedCollection<RolesViewModel>>() } 
        };
    }

    public async Task<CreateResponse> CreateAsync(CreateCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(cancellationToken);
        
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
        var loadData = await _loadGrpcChannelAsync(cancellationToken);
        
        UpdateRequest payload = new();
        
        payload.TargetId = request.RoleId != null ? new String { Value = request.RoleId } : null;
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
        var loadData = await _loadGrpcChannelAsync(cancellationToken);
        
        var payload = new DeleteRequest {
            TargetId = request.RoleId != null ? new String { Value = request.RoleId } : null
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
            new RoleService.RoleServiceClient(_channel)
        );
    }
}