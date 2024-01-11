using Grpc.Core;
using Grpc.Net.Client;
using Karami.Core.Common.ClassConsts;
using Karami.Core.Common.ClassHelpers;
using Karami.Core.Grpc.AggregateArticle;
using Karami.Core.Infrastructure.Extensions;
using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.Infrastructure.Extensions;
using Karami.UseCase.AggregateArticleUseCase.Contracts.Interfaces;
using Karami.UseCase.AggregateArticleUseCase.Queries.ReadAllPaginated;
using Karami.UseCase.ArticleUseCase.DTOs.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

using Int32                        = Karami.Core.Grpc.AggregateArticle.Int32;
using ReadAllPaginatedResponse     = Karami.UseCase.AggregateArticleUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponse;
using ReadAllPaginatedResponseBody = Karami.UseCase.AggregateArticleUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponseBody;

namespace Karami.Infrastructure.Implementations.UseCase.Services;

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
        var loadData = await _loadGrpcChannelAsync(cancellationToken);
        
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
        _loadGrpcChannelAsync(CancellationToken cancellationToken)
    {
        var targetServiceInstance =
            await _serviceDiscovery.LoadAddressInMemoryAsync(Service.CommentService, cancellationToken);
        
        _channel = GrpcChannel.ForAddress(targetServiceInstance, new GrpcChannelOptions().GetAll());

        return (
            new() {
                { Header.Token   , _httpContextAccessor.HttpContext.GetRowToken() },
                { Header.License , _configuration.GetValue<string>("SecretKey") }
            },
            new AggregateArticleService.AggregateArticleServiceClient(_channel)
        );
    }
}