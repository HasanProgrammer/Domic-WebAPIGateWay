using Domic.UseCase.AggregateArticleUseCase.Contracts.Interfaces;
using Domic.UseCase.AggregateArticleUseCase.DTOs.GRPCs.ReadAllPaginated;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.AggregateArticleUseCase.Queries.ReadAllPaginated;

public class ReadAllPaginatedQueryHandler : IQueryHandler<ReadAllPaginatedQuery, ReadAllPaginatedResponse>
{
    private readonly IAggregateArticleRpcWebRequest _aggregateArticleRpcWebRequest;

    public ReadAllPaginatedQueryHandler(IAggregateArticleRpcWebRequest aggregateArticleRpcWebRequest
    ) => _aggregateArticleRpcWebRequest = aggregateArticleRpcWebRequest;

    [WithValidation]
    public Task<ReadAllPaginatedResponse> HandleAsync(ReadAllPaginatedQuery query,
        CancellationToken cancellationToken
    ) => _aggregateArticleRpcWebRequest.ReadAllPaginatedAsync(query, cancellationToken);
}