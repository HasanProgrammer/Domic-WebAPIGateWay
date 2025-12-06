using Domic.UseCase.AggregateSeasonUseCase.DTOs.GRPCs.ReadAllPaginated;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.AggregateSeasonUseCase.Contracts.Interfaces;

namespace Domic.UseCase.AggregateSeasonUseCase.Queries.ReadAllPaginated;

public class ReadAllPaginatedQueryHandler(IAggregateSeasonRpcWebRequest aggregateSeasonRpcWebRequest) 
    : IQueryHandler<ReadAllPaginatedQuery, ReadAllPaginatedResponse>
{
    [WithValidation]
    public Task<ReadAllPaginatedResponse> HandleAsync(ReadAllPaginatedQuery query, CancellationToken cancellationToken) 
        => aggregateSeasonRpcWebRequest.ReadAllPaginatedAsync(query, cancellationToken);
}