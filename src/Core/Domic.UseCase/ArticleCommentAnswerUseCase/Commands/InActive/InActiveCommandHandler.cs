#pragma warning disable CS4014

using Domic.UseCase.ArticleCommentAnswerUseCase.Contracts.Interfaces;
using Domic.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.InActive;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.ArticleCommentAnswerUseCase.Commands.InActive;

public class InActiveCommandHandler : ICommandHandler<InActiveCommand, InActiveResponse>
{
    private readonly IArticleCommentAnswerRpcWebRequest _articleCommentAnswerRpcWebRequest;

    public InActiveCommandHandler(IArticleCommentAnswerRpcWebRequest articleCommentAnswerRpcWebRequest)
        => _articleCommentAnswerRpcWebRequest = articleCommentAnswerRpcWebRequest;
    
    public async Task<InActiveResponse> HandleAsync(InActiveCommand command, CancellationToken cancellationToken)
        => await _articleCommentAnswerRpcWebRequest.InActiveAsync(command, cancellationToken);
}