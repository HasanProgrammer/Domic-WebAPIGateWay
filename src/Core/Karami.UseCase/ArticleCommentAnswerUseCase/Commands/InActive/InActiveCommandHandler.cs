#pragma warning disable CS4014

using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.ArticleCommentAnswerUseCase.Contracts.Interfaces;
using Karami.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.InActive;

namespace Karami.UseCase.ArticleCommentAnswerUseCase.Commands.InActive;

public class InActiveCommandHandler : ICommandHandler<InActiveCommand, InActiveResponse>
{
    private readonly IArticleCommentAnswerRpcWebRequest _articleCommentAnswerRpcWebRequest;

    public InActiveCommandHandler(IArticleCommentAnswerRpcWebRequest articleCommentAnswerRpcWebRequest)
        => _articleCommentAnswerRpcWebRequest = articleCommentAnswerRpcWebRequest;
    
    public async Task<InActiveResponse> HandleAsync(InActiveCommand command, CancellationToken cancellationToken)
        => await _articleCommentAnswerRpcWebRequest.InActiveAsync(command, cancellationToken);
}