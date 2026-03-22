using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.AggregateTermUseCase.Contracts.Interfaces;
using Domic.UseCase.AggregateTermUseCase.DTOs.GRPCs.LandingReadAllPaginated;

namespace Domic.UseCase.AggregateTermUseCase.Queries.LandingReadAllPaginated;

public class LandingReadAllPaginatedQueryHandler(IAggregateTermRpcWebRequest aggregateTermRpcWebRequest) 
    : IQueryHandler<LandingReadAllPaginatedQuery, LandingReadAllPaginatedResponse>
{
    [WithValidation]
    public Task<LandingReadAllPaginatedResponse> HandleAsync(LandingReadAllPaginatedQuery query, 
        CancellationToken cancellationToken
    ) => aggregateTermRpcWebRequest.LandingReadAllPaginatedAsync(query, cancellationToken);
}