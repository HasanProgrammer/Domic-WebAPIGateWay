using Domic.UseCase.AggregateTicketUseCase.DTOs.GRPCs.ReadAllPaginated;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.AggregateTicketUseCase.Contracts.Interfaces;

namespace Domic.UseCase.AggregateTicketUseCase.Queries.ReadAllPaginated;

public class ReadAllPaginatedQueryHandler(IAggregateTicketRpcWebRequest aggregateTicketRpcWebRequest) 
    : IQueryHandler<ReadAllPaginatedQuery, ReadAllPaginatedResponse>
{
    [WithValidation]
    public Task<ReadAllPaginatedResponse> HandleAsync(ReadAllPaginatedQuery query, CancellationToken cancellationToken) 
        => aggregateTicketRpcWebRequest.ReadAllPaginatedAsync(query, cancellationToken);
}