using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.ArticleUseCase.DTOs.GRPCs.Active;
using Karami.UseCase.RoleUseCase.Contracts.Interfaces;

namespace Karami.UseCase.ArticleUseCase.Commands.Active;

public class ActiveCommandHandler : ICommandHandler<ActiveCommand, ActiveResponse>
{
    private readonly IArticleRpcWebRequest _articleRpcWebRequest;

    public ActiveCommandHandler(IArticleRpcWebRequest articleRpcWebRequest) 
        => _articleRpcWebRequest = articleRpcWebRequest;

    public async Task<ActiveResponse> HandleAsync(ActiveCommand command, CancellationToken cancellationToken)
        => await _articleRpcWebRequest.ActiveAsync(command, cancellationToken);
}