using Domic.Core.Auth.Grpc;
using Grpc.Core;
using Grpc.Net.Client;
using Domic.Core.Common.ClassConsts;
using Domic.Core.Common.ClassHelpers;
using Domic.Core.Infrastructure.Extensions;
using Domic.Core.Term.Grpc;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Core.User.Grpc;
using Domic.Infrastructure.Extensions;
using Domic.UseCase.TermUseCase.Contracts.Interfaces;
using Domic.UseCase.TermUseCase.Commands.Active;
using Domic.UseCase.TermUseCase.Commands.Update;
using Domic.UseCase.TermUseCase.Commands.Create;
using Domic.UseCase.TermUseCase.Commands.InActive;
using Domic.UseCase.TermUseCase.DTOs.ViewModels;
using Domic.UseCase.TermUseCase.Queries.ReadAllPaginated;
using Domic.UseCase.TermUseCase.Queries.ReadOne;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using ActiveRequest = Domic.Core.Term.Grpc.ActiveRequest;
using String                       = Domic.Core.Term.Grpc.String;
using Int32                        = Domic.Core.Term.Grpc.Int32;
using ReadOneResponse              = Domic.UseCase.TermUseCase.DTOs.GRPCs.ReadOne.ReadOneResponse;
using ReadOneResponseBody          = Domic.UseCase.TermUseCase.DTOs.GRPCs.ReadOne.ReadOneResponseBody;
using CreateResponse               = Domic.UseCase.TermUseCase.DTOs.GRPCs.Create.CreateResponse;
using CreateResponseBody           = Domic.UseCase.TermUseCase.DTOs.GRPCs.Create.CreateResponseBody;
using ReadAllPaginatedResponse     = Domic.UseCase.TermUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponse;
using ReadAllPaginatedResponseBody = Domic.UseCase.TermUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponseBody;
using UpdateResponse               = Domic.UseCase.TermUseCase.DTOs.GRPCs.Update.UpdateResponse;
using UpdateResponseBody           = Domic.UseCase.TermUseCase.DTOs.GRPCs.Update.UpdateResponseBody;
using ActiveResponse               = Domic.UseCase.TermUseCase.DTOs.GRPCs.Active.ActiveResponse;
using ActiveResponseBody           = Domic.UseCase.TermUseCase.DTOs.GRPCs.Active.ActiveResponseBody;
using CheckExistRequest = Domic.Core.Term.Grpc.CheckExistRequest;
using CreateRequest = Domic.Core.Term.Grpc.CreateRequest;
using InActiveRequest = Domic.Core.Term.Grpc.InActiveRequest;
using InActiveResponse             = Domic.UseCase.TermUseCase.DTOs.GRPCs.InActive.InActiveResponse;
using InActiveResponseBody         = Domic.UseCase.TermUseCase.DTOs.GRPCs.InActive.InActiveResponseBody;
using ReadAllPaginatedRequest = Domic.Core.Term.Grpc.ReadAllPaginatedRequest;
using ReadOneRequest = Domic.Core.Term.Grpc.ReadOneRequest;
using UpdateRequest = Domic.Core.Term.Grpc.UpdateRequest;

namespace Domic.Infrastructure.Implementations.UseCase.Services;

public class TermRpcWebRequest(
    IServiceDiscovery serviceDiscovery, IHttpContextAccessor httpContextAccessor, IConfiguration configuration
) : ITermRpcWebRequest
{
    private GrpcChannel _channel;

    public async Task<bool> CheckExistAsync(string id, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelForTermServiceAsync(cancellationToken);
        
        CheckExistRequest payload = new() { TermId = !string.IsNullOrEmpty(id) ? new String { Value = id } : null };

        var result =
            await loadData.client.CheckExistAsync(payload, headers: loadData.headers, 
                cancellationToken: cancellationToken
            );

        return result.Result;
    }

    public async Task<ReadOneResponse> ReadOneAsync(ReadOneQuery request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelForTermServiceAsync(cancellationToken);
        
        ReadOneRequest payload = new() {
            TermId = request.TermId != null ? new String { Value = request.TermId } : null
        };

        var result = 
            await loadData.client.ReadOneAsync(payload, headers: loadData.headers, 
                cancellationToken: cancellationToken
            );

        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ReadOneResponseBody { Term = result.Body.Term.DeSerialize<TermsDto>() } 
        };
    }

    public async Task<ReadAllPaginatedResponse> ReadAllPaginatedAsync(ReadAllPaginatedQuery request,
        CancellationToken cancellationToken
    )
    {
        var loadData = await _loadGrpcChannelForTermServiceAsync(cancellationToken);
        
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
                Terms = result.Body.Terms.DeSerialize<PaginatedCollection<TermsDto>>()
            }
        };
    }

    public async Task<CreateResponse> CreateAsync(CreateCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelForTermServiceAsync(cancellationToken);
        
        CreateRequest payload = new();

        payload.Name        = request.Name        != null ? new String { Value = request.Name }        : null;
        payload.Description = request.Description != null ? new String { Value = request.Description } : null;
        payload.ImageUrl    = request.ImageUrl    != null ? new String { Value = request.ImageUrl }    : null;
        payload.Status      = request.Status      != null ? new Int32  { Value = (int)request.Status } : null;
        
        var result = 
            await loadData.client.CreateAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new CreateResponseBody { TermId = result.Body.TermId }
        };
    }

    public async Task<UpdateResponse> UpdateAsync(UpdateCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelForTermServiceAsync(cancellationToken);
        
        UpdateRequest payload = new();

        payload.TermId      = request.TermId      != null ? new String { Value = request.TermId }      : null;
        payload.Name        = request.Name        != null ? new String { Value = request.Name }        : null;
        payload.Description = request.Description != null ? new String { Value = request.Description } : null;
        payload.ImageUrl    = request.ImageUrl    != null ? new String { Value = request.ImageUrl }    : null;
        payload.Status      = request.Status      != null ? new Int32  { Value = (int)request.Status } : null;
        
        var result =
            await loadData.client.UpdateAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new UpdateResponseBody { TermId = result.Body.TermId }
        };
    }

    public async Task<ActiveResponse> ActiveAsync(ActiveCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelForTermServiceAsync(cancellationToken);
        
        ActiveRequest payload = new();

        payload.TermId = request.TermId is not null ? new String { Value = request.TermId } : null;

        var result = 
            await loadData.client.ActiveAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);

        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ActiveResponseBody { TermId = result.Body.TermId } 
        };
    }

    public async Task<InActiveResponse> InActiveAsync(InActiveCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelForTermServiceAsync(cancellationToken);
        
        InActiveRequest payload = new();

        payload.TermId = request.TermId is not null ? new String { Value = request.TermId } : null;

        var result = 
            await loadData.client.InActiveAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);

        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new InActiveResponseBody { TermId = result.Body.TermId } 
        };
    }

    public void Dispose() => _channel.Dispose();
    
    /*---------------------------------------------------------------*/

    private async Task<(Metadata headers, TermService.TermServiceClient client)> 
        _loadGrpcChannelForTermServiceAsync(CancellationToken cancellationToken)
    {
        var targetServiceInstance =
            await serviceDiscovery.LoadAddressInMemoryAsync(Service.TermService, cancellationToken);
        
        _channel = GrpcChannel.ForAddress(targetServiceInstance, new GrpcChannelOptions().GetAll());

        return (
            new() {
                { Header.Token   , httpContextAccessor.HttpContext.GetRowToken() },
                { Header.License , configuration.GetValue<string>("SecretKey") }
            },
            new TermService.TermServiceClient(_channel)
        );
    }
}