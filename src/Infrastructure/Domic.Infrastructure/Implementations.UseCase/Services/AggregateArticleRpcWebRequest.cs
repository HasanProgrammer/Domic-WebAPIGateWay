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
using Domic.UseCase.ArticleUseCase.DTOs.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

using Int32                        = Domic.Core.AggregateArticle.Grpc.Int32;
using ReadAllPaginatedResponse     = Domic.UseCase.AggregateArticleUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponse;
using ReadAllPaginatedResponseBody = Domic.UseCase.AggregateArticleUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponseBody;

namespace Domic.Infrastructure.Implementations.UseCase.Services;

public class AggregateArticleRpcWebRequest : IAggregateArticleRpcWebRequest
{
    private readonly IServiceDiscovery    _serviceDiscovery;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IConfiguration       _configuration;
    
    private GrpcChannel _channel;

    public AggregateArticleRpcWebRequest(IServiceDiscovery serviceDiscovery, IHttpContextAccessor httpContextAccessor,
        IConfiguration configuration
    )
    {
        _serviceDiscovery    = serviceDiscovery;
        _httpContextAccessor = httpContextAccessor;
        _configuration       = configuration;
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
            await loadData.client.ReadAllPaginatedAsync(payload, cancellationToken: cancellationToken, 
                headers: loadData.headers
            );
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ReadAllPaginatedResponseBody {
                Articles = result.Body.Articles.DeSerialize<PaginatedCollection<AggregateArticlesViewModel>>()
            }
        };
    }

    public void Dispose()
    {
        _channel.Dispose();
    }
    
    /*---------------------------------------------------------------*/

    private async Task<(Metadata headers, AggregateArticleService.AggregateArticleServiceClient client)> 
        _loadGrpcChannelAsync(bool isIdempotent, CancellationToken cancellationToken)
    {
        var targetServiceInstance =
            await _serviceDiscovery.LoadAddressInMemoryAsync(Service.CommentService, cancellationToken);
        
        _channel = GrpcChannel.ForAddress(targetServiceInstance, new GrpcChannelOptions().GetAll());

        var metaData = new Metadata {
            { Header.Token   , _httpContextAccessor.HttpContext.GetRowToken() } ,
            { Header.License , _configuration.GetValue<string>("SecretKey") }
        };
        
        if(isIdempotent == false)
            metaData.Add(Header.IdempotentKey, Guid.NewGuid().ToString());
        
        return ( metaData, new AggregateArticleService.AggregateArticleServiceClient(_channel) );
    }
}