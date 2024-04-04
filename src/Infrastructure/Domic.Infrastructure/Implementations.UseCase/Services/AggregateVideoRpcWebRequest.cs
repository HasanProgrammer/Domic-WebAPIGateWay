using Grpc.Core;
using Grpc.Net.Client;
using Domic.Core.Common.ClassConsts;
using Domic.Core.Common.ClassHelpers;
using Domic.Core.AggregateVideo.Grpc;
using Domic.Core.Infrastructure.Extensions;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Infrastructure.Extensions;
using Domic.UseCase.AggregateVideoUseCase.Queries.ReadAllPaginated;
using Domic.UseCase.AggregateVideoUseCase.Contracts.Interfaces;
using Domic.UseCase.AggregateVideoUseCase.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

using Int32                        = Domic.Core.AggregateVideo.Grpc.Int32;
using ReadAllPaginatedRequest      = Domic.Core.AggregateVideo.Grpc.ReadAllPaginatedRequest;
using ReadAllPaginatedResponse     = Domic.UseCase.AggregateVideoUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponse;
using ReadAllPaginatedResponseBody = Domic.UseCase.AggregateVideoUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponseBody;

namespace Domic.Infrastructure.Implementations.UseCase.Services;

public class AggregateVideoRpcWebRequest(
    IServiceDiscovery serviceDiscovery, IHttpContextAccessor httpContextAccessor, IConfiguration configuration
)
: IAggregateVideoRpcWebRequest
{
    private GrpcChannel _channel;

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
                Videos = result.Body.Videos.DeSerialize<PaginatedCollection<AggregateVideosDto>>()
            }
        };
    }

    public void Dispose()
    {
        _channel.Dispose();
    }
    
    /*---------------------------------------------------------------*/

    private async Task<(Metadata headers, AggregateVideoService.AggregateVideoServiceClient client)> 
        _loadGrpcChannelAsync(CancellationToken cancellationToken)
    {
        var targetServiceInstance =
            await serviceDiscovery.LoadAddressInMemoryAsync("AggregateTermService", cancellationToken);
        
        _channel = GrpcChannel.ForAddress(targetServiceInstance, new GrpcChannelOptions().GetAll());

        return (
            new() {
                { Header.Token   , httpContextAccessor.HttpContext.GetRowToken() },
                { Header.License , configuration.GetValue<string>("SecretKey") }
            },
            new AggregateVideoService.AggregateVideoServiceClient(_channel)
        );
    }
}