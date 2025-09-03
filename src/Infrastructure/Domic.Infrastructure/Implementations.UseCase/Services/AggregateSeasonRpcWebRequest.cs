using Grpc.Core;
using Grpc.Net.Client;
using Domic.Core.Common.ClassConsts;
using Domic.Core.Common.ClassHelpers;
using Domic.Core.AggregateSeason.Grpc;
using Domic.Core.Infrastructure.Extensions;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Infrastructure.Extensions;
using Domic.UseCase.AggregateSeasonUseCase.Contracts.Interfaces;
using Domic.UseCase.AggregateSeasonUseCase.DTOs;
using Domic.UseCase.AggregateSeasonUseCase.Queries.ReadAllPaginated;
using Domic.UseCase.AggregateSeasonUseCase.Queries.ReadOne;
using Microsoft.AspNetCore.Http;

using String                       = Domic.Core.AggregateSeason.Grpc.String;
using Int32                        = Domic.Core.AggregateSeason.Grpc.Int32;
using ReadAllPaginatedResponse     = Domic.UseCase.AggregateSeasonUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponse;
using ReadAllPaginatedResponseBody = Domic.UseCase.AggregateSeasonUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponseBody;
using ReadOneResponse              = Domic.UseCase.AggregateSeasonUseCase.DTOs.GRPCs.ReadOne.ReadOneResponse;
using ReadOneResponseBody          = Domic.UseCase.AggregateSeasonUseCase.DTOs.GRPCs.ReadOne.ReadOneResponseBody;

namespace Domic.Infrastructure.Implementations.UseCase.Services;

public class AggregateSeasonRpcWebRequest(
    IServiceDiscovery serviceDiscovery, IHttpContextAccessor httpContextAccessor, 
    IExternalDistributedCache distributedCache
) : IAggregateSeasonRpcWebRequest
{
    private GrpcChannel _channel;

    public async Task<ReadOneResponse> ReadOneAsync(ReadOneQuery request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(true, cancellationToken);
        
        ReadOneRequest payload = new() {
            Id = request.Id != null ? new String { Value = request.Id } : null
        };

        var result =
            await loadData.client.ReadOneAsync(payload, cancellationToken: cancellationToken,
                headers: loadData.headers
            );
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ReadOneResponseBody {
                Season = result.Body.Season.DeSerialize<AggregateSeasonDto>()
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

        payload.Active     = request.Active;
        payload.Sort       = new Int32 { Value = request.Sort };
        payload.UserId     = !string.IsNullOrEmpty(request.UserId)     ? new String { Value = request.UserId }     : null;
        payload.SearchText = !string.IsNullOrEmpty(request.SearchText) ? new String { Value = request.SearchText } : null;

        var result =
            await loadData.client.ReadAllPaginatedAsync(payload, cancellationToken: cancellationToken,
                headers: loadData.headers
            );
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ReadAllPaginatedResponseBody {
                Seasons = result.Body.Seasons.DeSerialize<PaginatedCollection<AggregateSeasonDto>>()
            }
        };
    }

    public void Dispose()
    {
        _channel.Dispose();
    }
    
    /*---------------------------------------------------------------*/

    private async Task<(Metadata headers, AggregateSeasonService.AggregateSeasonServiceClient client)> 
        _loadGrpcChannelAsync(bool isIdempotent, CancellationToken cancellationToken)
    {
        var targetServiceInstanceTask = 
            serviceDiscovery.LoadAddressInMemoryAsync("AggregateTermService", cancellationToken);
        
        var secretKeyTask = distributedCache.GetCacheValueAsync("SecretKey", cancellationToken);

        await Task.WhenAll(targetServiceInstanceTask, secretKeyTask);
        
        _channel = GrpcChannel.ForAddress(await targetServiceInstanceTask, new GrpcChannelOptions().GetAll());

        var metaData = new Metadata {
            { Header.License , await secretKeyTask }
        };

        var token = httpContextAccessor.HttpContext.GetRowToken();
        
        if(token is not null)
            metaData.Add(Header.Token, token);
        
        if(isIdempotent == false)
            metaData.Add(Header.IdempotentKey, Guid.NewGuid().ToString());
        
        return ( metaData, new AggregateSeasonService.AggregateSeasonServiceClient(_channel) );
    }
}