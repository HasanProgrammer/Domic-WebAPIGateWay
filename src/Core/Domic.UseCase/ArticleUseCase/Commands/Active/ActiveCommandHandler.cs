using Domic.UseCase.ArticleUseCase.DTOs.GRPCs.Active;
using Domic.UseCase.RoleUseCase.Contracts.Interfaces;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.ArticleUseCase.Commands.Active;

public class ActiveCommandHandler : ICommandHandler<ActiveCommand, ActiveResponse>
{
    private readonly IArticleRpcWebRequest _articleRpcWebRequest;

    public ActiveCommandHandler(IArticleRpcWebRequest articleRpcWebRequest) 
        => _articleRpcWebRequest = articleRpcWebRequest;

    public async Task<ActiveResponse> HandleAsync(ActiveCommand command, CancellationToken cancellationToken)
        => await _articleRpcWebRequest.ActiveAsync(command, cancellationToken);
}