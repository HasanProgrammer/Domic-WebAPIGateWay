using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.ArticleUseCase.DTOs.GRPCs.ReadAllPaginated;
using Karami.UseCase.RoleUseCase.Contracts.Interfaces;

namespace Karami.UseCase.ArticleUseCase.Queries.ReadAllPaginated;

public class ReadAllPaginatedQueryHandler : IQueryHandler<ReadAllPaginatedQuery, ReadAllPaginatedResponse>
{
    private readonly IArticleRpcWebRequest _articleRpcWebRequest;

    public ReadAllPaginatedQueryHandler(IArticleRpcWebRequest articleRpcWebRequest)
        => _articleRpcWebRequest = articleRpcWebRequest;

    public async Task<ReadAllPaginatedResponse> HandleAsync(ReadAllPaginatedQuery query,
        CancellationToken cancellationToken
    ) => await _articleRpcWebRequest.ReadAllPaginatedAsync(query, cancellationToken);
}