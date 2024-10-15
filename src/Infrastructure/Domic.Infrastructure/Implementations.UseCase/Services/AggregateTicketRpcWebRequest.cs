using Grpc.Core;
using Grpc.Net.Client;
using Domic.Core.Common.ClassConsts;
using Domic.Core.Common.ClassHelpers;
using Domic.Core.AggregateTicket.Grpc;
using Domic.Core.Infrastructure.Extensions;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Infrastructure.Extensions;
using Domic.UseCase.AggregateTicketUseCase.DTOs;
using Domic.UseCase.AggregateTicketUseCase.Queries.ReadAllPaginated;
using Domic.UseCase.AggregateTicketUseCase.Contracts.Interfaces;
using Domic.UseCase.AggregateTicketUseCase.Queries.ReadOne;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

using Int32                        = Domic.Core.AggregateTicket.Grpc.Int32;
using ReadAllPaginatedResponse     = Domic.UseCase.AggregateTicketUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponse;
using ReadAllPaginatedResponseBody = Domic.UseCase.AggregateTicketUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponseBody;
using ReadOneResponse              = Domic.UseCase.AggregateTicketUseCase.DTOs.GRPCs.ReadOne.ReadOneResponse;
using ReadOneResponseBody          = Domic.UseCase.AggregateTicketUseCase.DTOs.GRPCs.ReadOne.ReadOneResponseBody;
using String                       = Domic.Core.AggregateTicket.Grpc.String;

namespace Domic.Infrastructure.Implementations.UseCase.Services;

public class AggregateTicketRpcWebRequest(
    IServiceDiscovery serviceDiscovery, IHttpContextAccessor httpContextAccessor, IConfiguration configuration
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
            UserId       = request.UserId       != null ? new String { Value = request.UserId }           : null,
            SearchText   = request.SearchText   != null ? new String { Value = request.SearchText }       : null,
            PageNumber   = request.PageNumber   != null ? new Int32 { Value = (int)request.PageNumber }   : null,
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
        var targetServiceInstance =
            await serviceDiscovery.LoadAddressInMemoryAsync("AggregateTicketService", cancellationToken);
        
        _channel = GrpcChannel.ForAddress(targetServiceInstance, new GrpcChannelOptions().GetAll());

        var metaData = new Metadata {
            { Header.Token   , httpContextAccessor.HttpContext.GetRowToken() } ,
            { Header.License , configuration.GetValue<string>("SecretKey") }
        };
        
        if(isIdempotent == false)
            metaData.Add(Header.IdempotentKey, Guid.NewGuid().ToString());
        
        return ( metaData, new AggregateTicketService.AggregateTicketServiceClient(_channel) );
    }
}