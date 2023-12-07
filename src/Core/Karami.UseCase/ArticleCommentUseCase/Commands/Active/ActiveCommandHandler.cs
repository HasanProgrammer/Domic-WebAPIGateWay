#pragma warning disable CS4014

using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.ArticleCommentUseCase.Contracts.Interfaces;
using Karami.UseCase.ArticleCommentUseCase.DTOs.GRPCs.Active;

namespace Karami.UseCase.ArticleCommentUseCase.Commands.Active;

public class ActiveCommandHandler : ICommandHandler<ActiveCommand, ActiveResponse>
{
    private readonly IArticleCommentRpcWebRequest _articleCommentRpcWebRequest;

    public ActiveCommandHandler(IArticleCommentRpcWebRequest articleCommentRpcWebRequest)
        => _articleCommentRpcWebRequest = articleCommentRpcWebRequest;

    public async Task<ActiveResponse> HandleAsync(ActiveCommand command, CancellationToken cancellationToken)
        => await _articleCommentRpcWebRequest.ActiveAsync(command, cancellationToken);
}