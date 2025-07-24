using Domic.UseCase.AggregateTermUseCase.DTOs.GRPCs.ReadAllPaginated;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.AggregateTermUseCase.Contracts.Interfaces;

namespace Domic.UseCase.AggregateTermUseCase.Queries.ReadAllPaginated;

public class ReadAllPaginatedQueryHandler(IAggregateTermRpcWebRequest aggregateTermRpcWebRequest) 
    : IQueryHandler<ReadAllPaginatedQuery, ReadAllPaginatedResponse>
{
    [WithValidation]
    public Task<ReadAllPaginatedResponse> HandleAsync(ReadAllPaginatedQuery query, CancellationToken cancellationToken) 
        => aggregateTermRpcWebRequest.ReadAllPaginatedAsync(query, cancellationToken);
}