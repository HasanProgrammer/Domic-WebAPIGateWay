using Karami.Core.UseCase.Attributes;
using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.AggregateArticleUseCase.Contracts.Interfaces;
using Karami.UseCase.AggregateArticleUseCase.DTOs.GRPCs.ReadAllPaginated;

namespace Karami.UseCase.AggregateArticleUseCase.Queries.ReadAllPaginated;

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