using Grpc.Core;
using Grpc.Net.Client;
using Domic.Core.Common.ClassConsts;
using Domic.Core.Common.ClassHelpers;
using Domic.Core.AggregateTerm.Grpc;
using Domic.Core.Infrastructure.Extensions;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Infrastructure.Extensions;
using Domic.UseCase.AggregateTermUseCase.Contracts.Interfaces;
using Domic.UseCase.AggregateTermUseCase.DTOs;
using Domic.UseCase.AggregateTermUseCase.Queries.ReadAllPaginated;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

using Int32                        = Domic.Core.AggregateTerm.Grpc.Int32;
using ReadAllPaginatedResponse     = Domic.UseCase.AggregateTermUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponse;
using ReadAllPaginatedResponseBody = Domic.UseCase.AggregateTermUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponseBody;

namespace Domic.Infrastructure.Implementations.UseCase.Services;

public class AggregateTermRpcWebRequest(
    IServiceDiscovery serviceDiscovery, IHttpContextAccessor httpContextAccessor, IConfiguration configuration
)
: IAggregateTermRpcWebRequest
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
                Terms = result.Body.Terms.DeSerialize<PaginatedCollection<AggregateTermsDto>>()
            }
        };
    }

    public void Dispose()
    {
        _channel.Dispose();
    }
    
    /*---------------------------------------------------------------*/

    private async Task<(Metadata headers, AggregateTermService.AggregateTermServiceClient client)> 
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
            new AggregateTermService.AggregateTermServiceClient(_channel)
        );
    }
}