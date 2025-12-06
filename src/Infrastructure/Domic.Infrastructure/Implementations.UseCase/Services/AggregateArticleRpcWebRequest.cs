using Grpc.Core;
using Grpc.Net.Client;
using Domic.Core.Common.ClassConsts;
using Domic.Core.Common.ClassHelpers;
using Domic.Core.AggregateArticle.Grpc;
using Domic.Core.Infrastructure.Extensions;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Infrastructure.Extensions;
using Domic.UseCase.AggregateArticleUseCase.Contracts.Interfaces;
using Domic.UseCase.AggregateArticleUseCase.Queries.ReadAllPaginated;
using Domic.UseCase.AggregateArticleUseCase.Queries.ReadOne;
using Domic.UseCase.ArticleUseCase.DTOs;
using Microsoft.AspNetCore.Http;

using Int32                        = Domic.Core.AggregateArticle.Grpc.Int32;
using String                       = Domic.Core.AggregateArticle.Grpc.String;
using ReadAllPaginatedResponse     = Domic.UseCase.AggregateArticleUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponse;
using ReadAllPaginatedResponseBody = Domic.UseCase.AggregateArticleUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponseBody;
using ReadOneResponse              = Domic.UseCase.AggregateArticleUseCase.DTOs.GRPCs.ReadOne.ReadOneResponse;
using ReadOneResponseBody          = Domic.UseCase.AggregateArticleUseCase.DTOs.GRPCs.ReadOne.ReadOneResponseBody;

namespace Domic.Infrastructure.Implementations.UseCase.Services;

public class AggregateArticleRpcWebRequest(
    IServiceDiscovery         serviceDiscovery,
    IHttpContextAccessor      httpContextAccessor,
    IExternalDistributedCache distributedCache
) : IAggregateArticleRpcWebRequest
{
    private GrpcChannel _channel;

    public async Task<ReadOneResponse> ReadOneAsync(ReadOneQuery request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(true, cancellationToken);
        
        ReadOneRequest payload = new() {
            Id = new String { Value = request.Id }
        };

        var result =
            await loadData.client.ReadOneAsync(payload, cancellationToken: cancellationToken, 
                headers: loadData.headers
            );
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ReadOneResponseBody {
                Article = result.Body.Article.DeSerialize<AggregateArticleDto>()
            }
        };
    }

    public async Task<ReadAllPaginatedResponse> ReadAllPaginatedAsync(ReadAllPaginatedQuery request, 
        CancellationToken cancellationToken
    )
    {
        var loadData = await _loadGrpcChannelAsync(true, cancellationToken);
        
        ReadAllPaginatedRequest payload = new() {
            PageNumber   = request.PageNumber   != null ? new Int32 { Value = (int)request.PageNumber }   : null,
            CountPerPage = request.CountPerPage != null ? new Int32 { Value = (int)request.CountPerPage } : null,
        };

        payload.IsActive   = request.IsActive;
        payload.SearchText = !string.IsNullOrWhiteSpace(request.SearchText) ? new String { Value = request.SearchText } : null;
        payload.UserId     = !string.IsNullOrWhiteSpace(request.UserId)     ? new String { Value = request.UserId }     : null;

        var result =
            await loadData.client.ReadAllPaginatedAsync(payload, cancellationToken: cancellationToken, 
                headers: loadData.headers
            );
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ReadAllPaginatedResponseBody {
                Articles = result.Body.Articles.DeSerialize<PaginatedCollection<AggregateArticleDto>>()
            }
        };
    }

    public void Dispose() => _channel.Dispose();
    
    /*---------------------------------------------------------------*/

    private async Task<(Metadata headers, AggregateArticleService.AggregateArticleServiceClient client)> 
        _loadGrpcChannelAsync(bool isIdempotent, CancellationToken cancellationToken)
    {
        var targetServiceInstanceTask = 
            serviceDiscovery.LoadAddressInMemoryAsync(Service.AggregateArticleService, cancellationToken);

        var secretKeyTask = distributedCache.GetCacheValueAsync("SecretKey", cancellationToken);

        await Task.WhenAll(targetServiceInstanceTask, secretKeyTask);
        
        _channel = GrpcChannel.ForAddress(await targetServiceInstanceTask, new GrpcChannelOptions().GetAll());

        var metaData = new Metadata {
            { Header.Token   , httpContextAccessor.HttpContext.GetRowToken() } ,
            { Header.License , await secretKeyTask }
        };
        
        if(isIdempotent == false)
            metaData.Add(Header.IdempotentKey, Guid.NewGuid().ToString());
        
        return ( metaData, new AggregateArticleService.AggregateArticleServiceClient(_channel) );
    }
}