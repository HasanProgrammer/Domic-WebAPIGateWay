using Grpc.Core;
using Grpc.Net.Client;
using Domic.Core.Common.ClassConsts;
using Domic.Core.Common.ClassHelpers;
using Domic.Core.Identity.Grpc;
using Domic.Core.User.Grpc;
using Domic.Core.Infrastructure.Extensions;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Commons.Enumerations;
using Domic.Infrastructure.Extensions;
using Domic.UseCase.UserUseCase.Commands.Active;
using Domic.UseCase.UserUseCase.Commands.Update;
using Domic.UseCase.UserUseCase.Commands.Create;
using Domic.UseCase.UserUseCase.Commands.InActive;
using Domic.UseCase.UserUseCase.Commands.OtpGeneration;
using Domic.UseCase.UserUseCase.Commands.OtpVerification;
using Domic.UseCase.UserUseCase.Commands.SignIn;
using Domic.UseCase.UserUseCase.Contracts.Interfaces;
using Domic.UseCase.UserUseCase.DTOs;
using Domic.UseCase.UserUseCase.Queries.ReadAllPaginated;
using Domic.UseCase.UserUseCase.Queries.ReadOne;
using Microsoft.AspNetCore.Http;
using String                       = Domic.Core.User.Grpc.String;
using AuthString                   = Domic.Core.Identity.Grpc.String;
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
using OtpGenerationResponse        = Domic.UseCase.UserUseCase.DTOs.GRPCs.OtpGeneration.OtpGenerationResponse;
using OtpGenerationResponseBody    = Domic.UseCase.UserUseCase.DTOs.GRPCs.OtpGeneration.OtpGenerationResponseBody;
using OtpVerificationResponse      = Domic.UseCase.UserUseCase.DTOs.GRPCs.OtpVerification.OtpVerificationResponse;
using OtpVerificationResponseBody  = Domic.UseCase.UserUseCase.DTOs.GRPCs.OtpVerification.OtpVerificationResponseBody;

namespace Domic.Infrastructure.Implementations.UseCase.Services;

public class UserRpcWebRequest : IUserRpcWebRequest
{
    private readonly IServiceDiscovery         _serviceDiscovery;
    private readonly IExternalDistributedCache _distributedCache;
    private readonly IHttpContextAccessor      _httpContextAccessor;

    private GrpcChannel _channel;

    public UserRpcWebRequest(IHttpContextAccessor httpContextAccessor,
        IServiceDiscovery serviceDiscovery, IExternalDistributedCache distributedCache
    )
    {
        _httpContextAccessor = httpContextAccessor;
        _serviceDiscovery    = serviceDiscovery;
        _distributedCache    = distributedCache;
    }

    public async Task<bool> CheckExistAsync(string id, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelForUserServiceAsync(true, cancellationToken);
        
        CheckExistRequest payload = new() { TargetId = !string.IsNullOrEmpty(id) ? new String { Value = id } : null };

        var result =
            await loadData.client.CheckExistAsync(payload, headers: loadData.headers, 
                cancellationToken: cancellationToken
            );

        return result.Result;
    }

    public async Task<ReadOneResponse> ReadOneAsync(ReadOneQuery request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelForUserServiceAsync(true, cancellationToken);
        
        ReadOneRequest payload = new() {
            TargetId = request.Id != null ? new String { Value = request.Id } : null
        };

        var result =
            await loadData.client.ReadOneAsync(payload, headers: loadData.headers, 
                cancellationToken: cancellationToken
            );

        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ReadOneResponseBody { User = result.Body.User.DeSerialize<UserDto>() } 
        };
    }

    public async Task<ReadAllPaginatedResponse> ReadAllPaginatedAsync(ReadAllPaginatedQuery request,
        CancellationToken cancellationToken
    )
    {
        var loadData = await _loadGrpcChannelForUserServiceAsync(true, cancellationToken);
        
        ReadAllPaginatedRequest payload = new() {
            PageNumber   = request.PageNumber   != null ? new Int32  { Value = (int)request.PageNumber }   : null ,
            CountPerPage = request.CountPerPage != null ? new Int32  { Value = (int)request.CountPerPage } : null
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
                Users = result.Body.Users.DeSerialize<PaginatedCollection<UserDto>>()
            }
        };
    }

    public async Task<CreateResponse> CreateAsync(CreateCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelForUserServiceAsync(false, cancellationToken);
        
        CreateRequest payload = new();

        payload.ImageUrl    = request.ImageUrl    != null ? new String { Value = request.ImageUrl }    : null;
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
        var loadData = await _loadGrpcChannelForAuthServiceAsync(false, cancellationToken);
        
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

    public async Task<OtpGenerationResponse> OtpGenerationAsync(OtpGenerationCommand request, 
        CancellationToken cancellationToken
    )
    {
        var loadData = await _loadGrpcChannelForAuthServiceAsync(false, cancellationToken);

        OtpGenerationRequest payload = new();
        
        payload.PhoneNumber = !string.IsNullOrEmpty(request.PhoneNumber) ? new AuthString { Value = request.PhoneNumber } : default;
        
        var result = 
            await loadData.client.OtpGenerationAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);

        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new OtpGenerationResponseBody { Result = result.Body.Result }
        };
    }

    public async Task<OtpVerificationResponse> OtpVerificationAsync(OtpVerificationCommand request, 
        CancellationToken cancellationToken
    )
    {
        var loadData = await _loadGrpcChannelForAuthServiceAsync(false, cancellationToken);

        OtpVerificationRequest payload = new();
        
        payload.Code        = !string.IsNullOrEmpty(request.Code)        ? new AuthString { Value = request.Code }        : default;
        payload.PhoneNumber = !string.IsNullOrEmpty(request.PhoneNumber) ? new AuthString { Value = request.PhoneNumber } : default;
        
        var result =
            await loadData.client.OtpVerificationAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);

        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new OtpVerificationResponseBody { Token = result.Body.Token }
        };
    }

    public async Task<UpdateResponse> UpdateAsync(UpdateCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelForUserServiceAsync(false, cancellationToken);
        
        UpdateRequest payload = new();

        payload.TargetId    = request.Id          != null ? new String { Value = request.Id }          : null;
        payload.ImageUrl    = request.ImageUrl    != null ? new String { Value = request.ImageUrl }    : null;
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
            await loadData.client.UpdateAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new UpdateResponseBody { UserId = result.Body.UserId }
        };
    }

    public async Task<ActiveResponse> ActiveAsync(ActiveCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelForUserServiceAsync(false, cancellationToken);
        
        ActiveRequest payload = new();

        payload.TargetId = request.Id is not null ? new String { Value = request.Id } : null;

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
        var loadData = await _loadGrpcChannelForUserServiceAsync(false, cancellationToken);
        
        InActiveRequest payload = new();

        payload.TargetId = request.Id is not null ? new String { Value = request.Id } : null;

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
        _loadGrpcChannelForUserServiceAsync(bool isIdempotent, CancellationToken cancellationToken)
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
        
        return ( metaData, new UserService.UserServiceClient(_channel) );
    }
    
    private async Task<(Metadata headers, IdentityService.IdentityServiceClient client)>
        _loadGrpcChannelForAuthServiceAsync(bool isIdempotent, CancellationToken cancellationToken)
    {
        var targetServiceInstanceTask =
            _serviceDiscovery.LoadAddressInMemoryAsync("IdentityService", cancellationToken);
        
        var secretKeyTask = _distributedCache.GetCacheValueAsync("SecretKey", cancellationToken);

        await Task.WhenAll(targetServiceInstanceTask, secretKeyTask);
        
        _channel = GrpcChannel.ForAddress(await targetServiceInstanceTask, new GrpcChannelOptions().GetAll());

        var metaData = new Metadata {
            { Header.License , await secretKeyTask }
        };
        
        if(isIdempotent == false)
            metaData.Add(Header.IdempotentKey, Guid.NewGuid().ToString());
        
        return ( metaData, new IdentityService.IdentityServiceClient(_channel) );
    }
}