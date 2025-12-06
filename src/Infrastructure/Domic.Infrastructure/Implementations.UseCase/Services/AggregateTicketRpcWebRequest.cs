using Grpc.Core;
using Grpc.Net.Client;
using Domic.Core.Common.ClassConsts;
using Domic.Core.Common.ClassHelpers;
using Domic.Core.AggregateTicket.Grpc;
using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.Infrastructure.Extensions;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Infrastructure.Extensions;
using Domic.UseCase.AggregateTicketUseCase.DTOs;
using Domic.UseCase.AggregateTicketUseCase.Queries.ReadAllPaginated;
using Domic.UseCase.AggregateTicketUseCase.Contracts.Interfaces;
using Domic.UseCase.AggregateTicketUseCase.Queries.ReadOne;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Int32                        = Domic.Core.AggregateTicket.Grpc.Int32;
using ReadAllPaginatedResponse     = Domic.UseCase.AggregateTicketUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponse;
using ReadAllPaginatedResponseBody = Domic.UseCase.AggregateTicketUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponseBody;
using ReadOneResponse              = Domic.UseCase.AggregateTicketUseCase.DTOs.GRPCs.ReadOne.ReadOneResponse;
using ReadOneResponseBody          = Domic.UseCase.AggregateTicketUseCase.DTOs.GRPCs.ReadOne.ReadOneResponseBody;
using String                       = Domic.Core.AggregateTicket.Grpc.String;

namespace Domic.Infrastructure.Implementations.UseCase.Services;

public class AggregateTicketRpcWebRequest(
    IServiceDiscovery serviceDiscovery, IHttpContextAccessor httpContextAccessor,
    IExternalDistributedCache distributedCache, [FromKeyedServices("Http1")] IIdentityUser identityUser
)
: IAggregateTicketRpcWebRequest
{
    private GrpcChannel _channel;

    public async Task<ReadOneResponse> ReadOneAsync(ReadOneQuery request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(true, cancellationToken);

        var payload = new ReadOneRequest {
            TicketId = request.TicketId != null ? new String { Value = request.TicketId } : null,
            UserId   = request.UserId   != null ? new String { Value = request.UserId }   : null
        };
        
        var result =
            await loadData.client.ReadOneAsync(payload, cancellationToken: cancellationToken, 
                headers: loadData.headers
            );
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ReadOneResponseBody {
                Tickets = result.Body.Ticket.DeSerialize<AggregateTicketsDto>()
            }
        };
    }

    public async Task<ReadAllPaginatedResponse> ReadAllPaginatedAsync(ReadAllPaginatedQuery request, 
        CancellationToken cancellationToken
    )
    {
        var loadData = await _loadGrpcChannelAsync(true, cancellationToken);
        
        ReadAllPaginatedRequest payload = new() {
            Sort         = new Int32 { Value = request.Sort },
            SearchText   = request.SearchText   != null ? new String { Value = request.SearchText }       : null,
            PageNumber   = request.PageNumber   != null ? new Int32 { Value = (int)request.PageNumber }   : null,
            CountPerPage = request.CountPerPage != null ? new Int32 { Value = (int)request.CountPerPage } : null
        };

        if (!identityUser.GetRoles().Contains("SuperAdmin") && !identityUser.GetRoles().Contains("Admin"))
            payload.UserId = default;
        else
            payload.UserId = new String { Value = identityUser.GetIdentity() };

        var result =
            await loadData.client.ReadAllPaginatedAsync(payload, cancellationToken: cancellationToken, 
                headers: loadData.headers
            );
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ReadAllPaginatedResponseBody {
                Tickets = result.Body.Tickets.DeSerialize<PaginatedCollection<AggregateTicketsDto>>()
            }
        };
    }

    public void Dispose()
    {
        _channel.Dispose();
    }
    
    /*---------------------------------------------------------------*/

    private async Task<(Metadata headers, AggregateTicketService.AggregateTicketServiceClient client)> 
        _loadGrpcChannelAsync(bool isIdempotent, CancellationToken cancellationToken)
    {
        var targetServiceInstanceTask = 
            serviceDiscovery.LoadAddressInMemoryAsync("AggregateTicketService", cancellationToken);

        var secretKeyTask = distributedCache.GetCacheValueAsync("SecretKey", cancellationToken);

        await Task.WhenAll(targetServiceInstanceTask, secretKeyTask);
        
        _channel = GrpcChannel.ForAddress(await targetServiceInstanceTask, new GrpcChannelOptions().GetAll());

        var metaData = new Metadata {
            { Header.Token   , httpContextAccessor.HttpContext.GetRowToken() } ,
            { Header.License , await secretKeyTask }
        };
        
        if(isIdempotent == false)
            metaData.Add(Header.IdempotentKey, Guid.NewGuid().ToString());
        
        return ( metaData, new AggregateTicketService.AggregateTicketServiceClient(_channel) );
    }
}