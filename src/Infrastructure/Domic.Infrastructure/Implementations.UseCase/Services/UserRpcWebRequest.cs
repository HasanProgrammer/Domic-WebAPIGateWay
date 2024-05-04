using Grpc.Core;
using Grpc.Net.Client;
using Domic.Core.Common.ClassConsts;
using Domic.Core.Common.ClassHelpers;
using Domic.Core.Auth.Grpc;
using Domic.Core.User.Grpc;
using Domic.Core.Infrastructure.Extensions;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Infrastructure.Extensions;
using Domic.UseCase.UserUseCase.Commands.Active;
using Domic.UseCase.UserUseCase.Commands.Update;
using Domic.UseCase.UserUseCase.Commands.Create;
using Domic.UseCase.UserUseCase.Commands.InActive;
using Domic.UseCase.UserUseCase.Commands.SignIn;
using Domic.UseCase.UserUseCase.Contracts.Interfaces;
using Domic.UseCase.UserUseCase.DTOs.ViewModels;
using Domic.UseCase.UserUseCase.Queries.ReadAllPaginated;
using Domic.UseCase.UserUseCase.Queries.ReadOne;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

using String                       = Domic.Core.User.Grpc.String;
using AuthString                   = Domic.Core.Auth.Grpc.String;
using Int32                        = Domic.Core.User.Grpc.Int32;
using ReadOneResponse              = Domic.UseCase.UserUseCase.DTOs.GRPCs.ReadOne.ReadOneResponse;
using ReadOneResponseBody          = Domic.UseCase.UserUseCase.DTOs.GRPCs.ReadOne.ReadOneResponseBody;
using CreateResponse               = Domic.UseCase.UserUseCase.DTOs.GRPCs.Create.CreateResponse;
using CreateResponseBody           = Domic.UseCase.UserUseCase.DTOs.GRPCs.Create.CreateResponseBody;
using ReadAllPaginatedResponse     = Domic.UseCase.UserUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponse;
using ReadAllPaginatedResponseBody = Domic.UseCase.UserUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponseBody;
using SignInResponse               = Domic.UseCase.UserUseCase.DTOs.GRPCs.SignIn.SignInResponse;
using SignInResponseBody           = Domic.UseCase.UserUseCase.DTOs.GRPCs.SignIn.SignInResponseBody;
using UpdateResponse               = Domic.UseCase.UserUseCase.DTOs.GRPCs.Update.UpdateResponse;
using UpdateResponseBody           = Domic.UseCase.UserUseCase.DTOs.GRPCs.Update.UpdateResponseBody;
using ActiveResponse               = Domic.UseCase.UserUseCase.DTOs.GRPCs.Active.ActiveResponse;
using ActiveResponseBody           = Domic.UseCase.UserUseCase.DTOs.GRPCs.Active.ActiveResponseBody;
using InActiveResponse             = Domic.UseCase.UserUseCase.DTOs.GRPCs.InActive.InActiveResponse;
using InActiveResponseBody         = Domic.UseCase.UserUseCase.DTOs.GRPCs.InActive.InActiveResponseBody;

namespace Domic.Infrastructure.Implementations.UseCase.Services;

public class UserRpcWebRequest : IUserRpcWebRequest
{
    private readonly IServiceDiscovery    _serviceDiscovery;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IConfiguration       _configuration;
    
    private GrpcChannel _channel;

    public UserRpcWebRequest(IConfiguration configuration, IHttpContextAccessor httpContextAccessor,
        IServiceDiscovery serviceDiscovery
    )
    {
        _configuration       = configuration;
        _httpContextAccessor = httpContextAccessor;
        _serviceDiscovery    = serviceDiscovery;
    }

    public async Task<bool> CheckExistAsync(string id, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelForUserServiceAsync(cancellationToken);
        
        CheckExistRequest payload = new() { TargetId = !string.IsNullOrEmpty(id) ? new String { Value = id } : null };

        var result =
            await loadData.client.CheckExistAsync(payload, headers: loadData.headers, 
                cancellationToken: cancellationToken
            );

        return result.Result;
    }

    public async Task<ReadOneResponse> ReadOneAsync(ReadOneQuery request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelForUserServiceAsync(cancellationToken);
        
        ReadOneRequest payload = new() {
            TargetId = request.UserId != null ? new String { Value = request.UserId } : null
        };

        var result = 
            await loadData.client.ReadOneAsync(payload, headers: loadData.headers, 
                cancellationToken: cancellationToken
            );

        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ReadOneResponseBody { User = result.Body.User.DeSerialize<UsersViewModel>() } 
        };
    }

    public async Task<ReadAllPaginatedResponse> ReadAllPaginatedAsync(ReadAllPaginatedQuery request,
        CancellationToken cancellationToken
    )
    {
        var loadData = await _loadGrpcChannelForUserServiceAsync(cancellationToken);
        
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
                Users = result.Body.Users.DeSerialize<PaginatedCollection<UsersViewModel>>()
            }
        };
    }

    public async Task<CreateResponse> CreateAsync(CreateCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelForUserServiceAsync(cancellationToken);
        
        CreateRequest payload = new();

        payload.Username    = request.Username    != null ? new String { Value = request.Username }    : null;
        payload.Password    = request.Password    != null ? new String { Value = request.Password }    : null;
        payload.FirstName   = request.FirstName   != null ? new String { Value = request.FirstName }   : null;
        payload.LastName    = request.LastName    != null ? new String { Value = request.LastName }    : null;
        payload.PhoneNumber = request.PhoneNumber != null ? new String { Value = request.PhoneNumber } : null;
        payload.Email       = request.EMail       != null ? new String { Value = request.EMail }       : null;
        payload.Description = request.Description != null ? new String { Value = request.Description } : null;
        
        payload.Roles       = ( request.Roles       != null || request.Roles.Count > 0 )       ? new String { Value = request.Roles.Serialize() }       : null;
        payload.Permissions = ( request.Permissions != null || request.Permissions.Count > 0 ) ? new String { Value = request.Permissions.Serialize() } : null;
        
        var result = 
            await loadData.client.CreateAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new CreateResponseBody { UserId = result.Body.UserId }
        };
    }

    public async Task<SignInResponse> SignInAsync(SignInCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelForAuthServiceAsync(cancellationToken);
        
        SignInRequest payload = new();
        
        payload.Username = request.Username != null ? new AuthString { Value = request.Username } : null;
        payload.Password = request.Password != null ? new AuthString { Value = request.Password } : null;

        var result = 
            await loadData.client.SignInAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new SignInResponseBody { Token = result.Body.Token }
        };
    }

    public async Task<UpdateResponse> UpdateAsync(UpdateCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelForUserServiceAsync(cancellationToken);
        
        UpdateRequest payload = new();

        payload.TargetId    = request.UserId      != null ? new String { Value = request.UserId }      : null;
        payload.Username    = request.Username    != null ? new String { Value = request.Username }    : null;
        payload.Password    = request.Password    != null ? new String { Value = request.Password }    : null;
        payload.FirstName   = request.FirstName   != null ? new String { Value = request.FirstName }   : null;
        payload.LastName    = request.LastName    != null ? new String { Value = request.LastName }    : null;
        payload.PhoneNumber = request.PhoneNumber != null ? new String { Value = request.PhoneNumber } : null;
        payload.Email       = request.EMail       != null ? new String { Value = request.EMail }       : null;
        payload.Description = request.Description != null ? new String { Value = request.Description } : null;
        payload.IsActive    = request.IsActive;
        
        payload.Roles       = ( request.Roles       != null || request.Roles.Count > 0 )       ? new String { Value = request.Roles.Serialize() }       : null;
        payload.Permissions = ( request.Permissions != null || request.Permissions.Count > 0 ) ? new String { Value = request.Permissions.Serialize() } : null;

        var result = 
            await loadData.client.UpdateAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new UpdateResponseBody { UserId = result.Body.UserId }
        };
    }

    public async Task<ActiveResponse> ActiveAsync(ActiveCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelForUserServiceAsync(cancellationToken);
        
        ActiveRequest payload = new();

        payload.TargetId = request.UserId is not null ? new String { Value = request.UserId } : null;

        var result = 
            await loadData.client.ActiveAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);

        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ActiveResponseBody { UserId = result.Body.UserId } 
        };
    }

    public async Task<InActiveResponse> InActiveAsync(InActiveCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelForUserServiceAsync(cancellationToken);
        
        InActiveRequest payload = new();

        payload.TargetId = request.UserId is not null ? new String { Value = request.UserId } : null;

        var result = 
            await loadData.client.InActiveAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);

        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new InActiveResponseBody { UserId = result.Body.UserId } 
        };
    }

    public void Dispose()
    {
        _channel.Dispose();
    }
    
    /*---------------------------------------------------------------*/

    private async Task<(Metadata headers, UserService.UserServiceClient client)>
        _loadGrpcChannelForUserServiceAsync(CancellationToken cancellationToken)
    {
        var targetServiceInstance =
            await _serviceDiscovery.LoadAddressInMemoryAsync(Service.UserService, cancellationToken);
        
        _channel = GrpcChannel.ForAddress(targetServiceInstance, new GrpcChannelOptions().GetAll());

        //Todo : ( Tech Debt ) => Shoud be ignore ( CheckExists ) action!
        
        return (
            new() {
                { Header.Token         , _httpContextAccessor.HttpContext.GetRowToken() } ,
                { Header.License       , _configuration.GetValue<string>("SecretKey") }   ,
                { Header.IdempotentKey , Guid.NewGuid().ToString() }
            },
            new UserService.UserServiceClient(_channel)
        );
    }
    
    private async Task<(Metadata headers, AuthService.AuthServiceClient client)>
        _loadGrpcChannelForAuthServiceAsync(CancellationToken cancellationToken)
    {
        var targetServiceInstance =
            await _serviceDiscovery.LoadAddressInMemoryAsync(Service.AuthService, cancellationToken);
        
        _channel = GrpcChannel.ForAddress(targetServiceInstance, new GrpcChannelOptions().GetAll());

        return (
            new() {
                { Header.License       , _configuration.GetValue<string>("SecretKey") },
                { Header.IdempotentKey , Guid.NewGuid().ToString() }
            },
            new AuthService.AuthServiceClient(_channel)
        );
    }
}