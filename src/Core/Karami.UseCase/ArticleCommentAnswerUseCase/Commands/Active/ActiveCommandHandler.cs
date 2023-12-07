#pragma warning disable CS4014

using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.ArticleCommentAnswerUseCase.Contracts.Interfaces;
using Karami.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.Active;

namespace Karami.UseCase.ArticleCommentAnswerUseCase.Commands.Active;

public class ActiveCommandHandler : ICommandHandler<ActiveCommand, ActiveResponse>
{
    private readonly IArticleCommentAnswerRpcWebRequest _articleCommentAnswerRpcWebRequest;

    public ActiveCommandHandler(IArticleCommentAnswerRpcWebRequest articleCommentAnswerRpcWebRequest)
        => _articleCommentAnswerRpcWebRequest = articleCommentAnswerRpcWebRequest;
    
    public async Task<ActiveResponse> HandleAsync(ActiveCommand command, CancellationToken cancellationToken)
        => await _articleCommentAnswerRpcWebRequest.ActiveAsync(command, cancellationToken);
}