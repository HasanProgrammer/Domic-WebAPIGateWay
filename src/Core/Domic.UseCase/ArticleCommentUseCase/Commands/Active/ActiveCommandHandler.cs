#pragma warning disable CS4014

using Domic.UseCase.ArticleCommentUseCase.Contracts.Interfaces;
using Domic.UseCase.ArticleCommentUseCase.DTOs.GRPCs.Active;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.ArticleCommentUseCase.Commands.Active;

public class ActiveCommandHandler : ICommandHandler<ActiveCommand, ActiveResponse>
{
    private readonly IArticleCommentRpcWebRequest _articleCommentRpcWebRequest;

    public ActiveCommandHandler(IArticleCommentRpcWebRequest articleCommentRpcWebRequest)
        => _articleCommentRpcWebRequest = articleCommentRpcWebRequest;

    public async Task<ActiveResponse> HandleAsync(ActiveCommand command, CancellationToken cancellationToken)
        => await _articleCommentRpcWebRequest.ActiveAsync(command, cancellationToken);
}