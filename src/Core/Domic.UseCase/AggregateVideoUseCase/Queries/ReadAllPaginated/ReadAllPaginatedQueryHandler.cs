using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.AggregateVideoUseCase.Contracts.Interfaces;
using Domic.UseCase.AggregateVideoUseCase.DTOs.GRPCs.ReadAllPaginated;

namespace Domic.UseCase.AggregateVideoUseCase.Queries.ReadAllPaginated;

public class ReadAllPaginatedQueryHandler(IAggregateVideoRpcWebRequest aggregateVideoRpcWebRequest) 
    : IQueryHandler<ReadAllPaginatedQuery, ReadAllPaginatedResponse>
{
    [WithValidation]
    public Task<ReadAllPaginatedResponse> HandleAsync(ReadAllPaginatedQuery query, CancellationToken cancellationToken) 
        => aggregateVideoRpcWebRequest.ReadAllPaginatedAsync(query, cancellationToken);
}