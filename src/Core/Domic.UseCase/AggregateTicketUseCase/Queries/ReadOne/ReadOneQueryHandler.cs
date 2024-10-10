using Domic.UseCase.AggregateTicketUseCase.DTOs.GRPCs.ReadOne;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.AggregateTicketUseCase.Contracts.Interfaces;

namespace Domic.UseCase.AggregateTicketUseCase.Queries.ReadOne;

public class ReadOneQueryHandler(IAggregateTicketRpcWebRequest aggregateTicketRpcWebRequest) 
    : IQueryHandler<ReadOneQuery, ReadOneResponse>
{
    public Task<ReadOneResponse> HandleAsync(ReadOneQuery query, CancellationToken cancellationToken) 
        => aggregateTicketRpcWebRequest.ReadOneAsync(query, cancellationToken);
}