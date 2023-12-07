using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.ArticleUseCase.DTOs.GRPCs.InActive;
using Karami.UseCase.RoleUseCase.Contracts.Interfaces;

namespace Karami.UseCase.ArticleUseCase.Commands.InActive;

public class InActiveCommandHandler : ICommandHandler<InActiveCommand, InActiveResponse>
{
    private readonly IArticleRpcWebRequest _articleRpcWebRequest;

    public InActiveCommandHandler(IArticleRpcWebRequest articleRpcWebRequest) 
        => _articleRpcWebRequest = articleRpcWebRequest;

    public async Task<InActiveResponse> HandleAsync(InActiveCommand command, CancellationToken cancellationToken)
        => await _articleRpcWebRequest.InActiveAsync(command, cancellationToken);
}