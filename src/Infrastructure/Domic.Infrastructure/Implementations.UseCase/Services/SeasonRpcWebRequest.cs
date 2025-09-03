using Grpc.Core;
using Grpc.Net.Client;
using Domic.Core.Common.ClassConsts;
using Domic.Core.Common.ClassHelpers;
using Domic.Core.Infrastructure.Extensions;
using Domic.Core.Season.Grpc;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Infrastructure.Extensions;
using Domic.UseCase.SeasonUseCase.Commands.Active;
using Domic.UseCase.SeasonUseCase.Commands.Update;
using Domic.UseCase.SeasonUseCase.Commands.Create;
using Domic.UseCase.SeasonUseCase.Commands.InActive;
using Domic.UseCase.SeasonUseCase.Contracts.Interfaces;
using Domic.UseCase.SeasonUseCase.DTOs;
using Domic.UseCase.SeasonUseCase.Queries.ReadAllBasedOnTermId;
using Domic.UseCase.SeasonUseCase.Queries.ReadAllPaginated;
using Domic.UseCase.SeasonUseCase.Queries.ReadOne;
using Microsoft.AspNetCore.Http;

using String                           = Domic.Core.Season.Grpc.String;
using Int32                            = Domic.Core.Season.Grpc.Int32;
using ActiveRequest                    = Domic.Core.Season.Grpc.ActiveRequest;
using CheckExistRequest                = Domic.Core.Season.Grpc.CheckExistRequest;
using CreateRequest                    = Domic.Core.Season.Grpc.CreateRequest;
using InActiveRequest                  = Domic.Core.Season.Grpc.InActiveRequest;
using ReadAllPaginatedRequest          = Domic.Core.Season.Grpc.ReadAllPaginatedRequest;
using ReadOneRequest                   = Domic.Core.Season.Grpc.ReadOneRequest;
using UpdateRequest                    = Domic.Core.Season.Grpc.UpdateRequest;
using ReadOneResponse                  = Domic.UseCase.SeasonUseCase.DTOs.GRPCs.ReadOne.ReadOneResponse;
using ReadOneResponseBody              = Domic.UseCase.SeasonUseCase.DTOs.GRPCs.ReadOne.ReadOneResponseBody;
using CreateResponse                   = Domic.UseCase.SeasonUseCase.DTOs.GRPCs.Create.CreateResponse;
using CreateResponseBody               = Domic.UseCase.SeasonUseCase.DTOs.GRPCs.Create.CreateResponseBody;
using ReadAllPaginatedResponse         = Domic.UseCase.SeasonUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponse;
using ReadAllPaginatedResponseBody     = Domic.UseCase.SeasonUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponseBody;
using UpdateResponse                   = Domic.UseCase.SeasonUseCase.DTOs.GRPCs.Update.UpdateResponse;
using UpdateResponseBody               = Domic.UseCase.SeasonUseCase.DTOs.GRPCs.Update.UpdateResponseBody;
using ActiveResponse                   = Domic.UseCase.SeasonUseCase.DTOs.GRPCs.Active.ActiveResponse;
using ActiveResponseBody               = Domic.UseCase.SeasonUseCase.DTOs.GRPCs.Active.ActiveResponseBody;
using DeleteResponse                   = Domic.UseCase.SeasonUseCase.DTOs.GRPCs.Update.DeleteResponse;
using DeleteResponseBody               = Domic.UseCase.SeasonUseCase.DTOs.GRPCs.Update.DeleteResponseBody;
using InActiveResponse                 = Domic.UseCase.SeasonUseCase.DTOs.GRPCs.InActive.InActiveResponse;
using InActiveResponseBody             = Domic.UseCase.SeasonUseCase.DTOs.GRPCs.InActive.InActiveResponseBody;
using ReadAllBasedOnTermIdResponse     = Domic.UseCase.SeasonUseCase.DTOs.GRPCs.ReadAllBasedOnTermId.ReadAllBasedOnTermIdResponse;
using ReadAllBasedOnTermIdResponseBody = Domic.UseCase.SeasonUseCase.DTOs.GRPCs.ReadAllBasedOnTermId.ReadAllBasedOnTermIdResponseBody;

namespace Domic.Infrastructure.Implementations.UseCase.Services;

public class SeasonRpcWebRequest(
    IServiceDiscovery serviceDiscovery, IHttpContextAccessor httpContextAccessor,
    IExternalDistributedCache distributedCache
) : ISeasonRpcWebRequest
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
            Body    = new ReadOneResponseBody { Season = result.Body.Season.DeSerialize<SeasonDto>() } 
        };
    }

    public async Task<ReadAllBasedOnTermIdResponse> ReadAllBasedOnTermIdAsync(ReadAllBasedOnTermIdQuery request,
        CancellationToken cancellationToken
    )
    {
        var loadData = await _loadGrpcChannelAsync(true, cancellationToken);
        
        ReadAllBasedOnTermIdRequest payload = new() { TermId = new String { Value = request.TermId } };
        
        var result =
            await loadData.client.ReadAllBasedOnTermIdAsync(payload, headers: loadData.headers, 
                cancellationToken: cancellationToken
            );
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ReadAllBasedOnTermIdResponseBody {
                Seasons = result.Body.Seasons.DeSerialize<List<SeasonDto>>()
            }
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
    }

    public async Task<CreateResponse> CreateAsync(CreateCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        CreateRequest payload = new();

        payload.TermId  = request.TermId != null ? new String { Value = request.TermId } : null;
        payload.Name    = request.Name   != null ? new String { Value = request.Name }   : null;
        
        var result =
            await loadData.client.CreateAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new CreateResponseBody { Id = result.Body.SeasonId }
        };
    }

    public async Task<UpdateResponse> UpdateAsync(UpdateCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        UpdateRequest payload = new();

        payload.Id     = request.Id     != null ? new String { Value = request.Id }     : null;
        payload.TermId = request.TermId != null ? new String { Value = request.TermId } : null;
        payload.Name   = request.Name   != null ? new String { Value = request.Name }   : null;
        
        var result =
            await loadData.client.UpdateAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new UpdateResponseBody { Id = result.Body.Id }
        };
    }

    public async Task<DeleteResponse> DeleteAsync(DeleteCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        DeleteRequest payload = new();

        payload.Id = request.Id is not null ? new String { Value = request.Id } : null;

        var result = 
            await loadData.client.DeleteAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);

        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new DeleteResponseBody { Id = result.Body.Id } 
        };
    }

    public async Task<ActiveResponse> ActiveAsync(ActiveCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        ActiveRequest payload = new();

        payload.Id = request.Id is not null ? new String { Value = request.Id } : null;

        var result = 
            await loadData.client.ActiveAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);

        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ActiveResponseBody { Id = result.Body.Id } 
        };
    }

    public async Task<InActiveResponse> InActiveAsync(InActiveCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        InActiveRequest payload = new();

        payload.Id = request.Id is not null ? new String { Value = request.Id } : null;

        var result = 
            await loadData.client.InActiveAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);

        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new InActiveResponseBody { Id = result.Body.Id } 
        };
    }

    public void Dispose() => _channel.Dispose();
    
    /*---------------------------------------------------------------*/

    private async Task<(Metadata headers, SeasonService.SeasonServiceClient client)> 
        _loadGrpcChannelAsync(bool isIdempotent, CancellationToken cancellationToken)
    {
        var targetServiceInstanceTask =
            serviceDiscovery.LoadAddressInMemoryAsync(Service.TermService, cancellationToken);
        
        var secretKeyTask = distributedCache.GetCacheValueAsync("SecretKey", cancellationToken);

        await Task.WhenAll(targetServiceInstanceTask, secretKeyTask);
        
        _channel = GrpcChannel.ForAddress(await targetServiceInstanceTask, new GrpcChannelOptions().GetAll());
        
        var metaData = new Metadata {
            { Header.Token   , httpContextAccessor.HttpContext.GetRowToken() } ,
            { Header.License , await secretKeyTask }
        };
        
        if(isIdempotent == false)
            metaData.Add(Header.IdempotentKey, Guid.NewGuid().ToString());
        
        return ( metaData, new SeasonService.SeasonServiceClient(_channel) );
    }
}