using Domic.UseCase.ArticleUseCase.DTOs.GRPCs.ReadAllPaginated;
using Domic.UseCase.RoleUseCase.Contracts.Interfaces;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.ArticleUseCase.Queries.ReadAllPaginated;

public class ReadAllPaginatedQueryHandler : IQueryHandler<ReadAllPaginatedQuery, ReadAllPaginatedResponse>
{
    private readonly IArticleRpcWebRequest _articleRpcWebRequest;

    public ReadAllPaginatedQueryHandler(IArticleRpcWebRequest articleRpcWebRequest)
        => _articleRpcWebRequest = articleRpcWebRequest;

    public async Task<ReadAllPaginatedResponse> HandleAsync(ReadAllPaginatedQuery query,
        CancellationToken cancellationToken
    ) => await _articleRpcWebRequest.ReadAllPaginatedAsync(query, cancellationToken);
}