using Domic.UseCase.ArticleUseCase.DTOs.GRPCs.ReadOne;
using Domic.UseCase.RoleUseCase.Contracts.Interfaces;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.ArticleUseCase.Queries.ReadOne;

public class ReadOneQueryHandler : IQueryHandler<ReadOneQuery, ReadOneResponse>
{
    private readonly IArticleRpcWebRequest _articleRpcWebRequest;

    public ReadOneQueryHandler(IArticleRpcWebRequest articleRpcWebRequest) 
        => _articleRpcWebRequest = articleRpcWebRequest;

    public Task<ReadOneResponse> HandleAsync(ReadOneQuery query, CancellationToken cancellationToken)
        => _articleRpcWebRequest.ReadOneAsync(query, cancellationToken);
}