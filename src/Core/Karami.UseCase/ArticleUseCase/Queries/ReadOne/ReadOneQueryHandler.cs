using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.ArticleUseCase.DTOs.GRPCs.ReadOne;
using Karami.UseCase.RoleUseCase.Contracts.Interfaces;

namespace Karami.UseCase.ArticleUseCase.Queries.ReadOne;

public class ReadOneQueryHandler : IQueryHandler<ReadOneQuery, ReadOneResponse>
{
    private readonly IArticleRpcWebRequest _articleRpcWebRequest;

    public ReadOneQueryHandler(IArticleRpcWebRequest articleRpcWebRequest) 
        => _articleRpcWebRequest = articleRpcWebRequest;

    public async Task<ReadOneResponse> HandleAsync(ReadOneQuery query, CancellationToken cancellationToken)
        => await _articleRpcWebRequest.ReadOneAsync(query, cancellationToken);
}