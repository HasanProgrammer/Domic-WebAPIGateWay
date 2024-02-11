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
    public async Task<ReadAllPaginatedResponse> HandleAsync(ReadAllPaginatedQuery query,
        CancellationToken cancellationToken
    ) => await _aggregateArticleRpcWebRequest.ReadAllPaginatedAsync(query, cancellationToken);
}