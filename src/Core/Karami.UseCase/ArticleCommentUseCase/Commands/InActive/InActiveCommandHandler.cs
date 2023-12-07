#pragma warning disable CS4014

using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.ArticleCommentUseCase.Contracts.Interfaces;
using Karami.UseCase.ArticleCommentUseCase.DTOs.GRPCs.InActive;

namespace Karami.UseCase.ArticleCommentUseCase.Commands.InActive;

public class InActiveCommandHandler : ICommandHandler<InActiveCommand, InActiveResponse>
{
    private readonly IArticleCommentRpcWebRequest _articleCommentRpcWebRequest;

    public InActiveCommandHandler(IArticleCommentRpcWebRequest articleCommentRpcWebRequest)
        => _articleCommentRpcWebRequest = articleCommentRpcWebRequest;

    public async Task<InActiveResponse> HandleAsync(InActiveCommand command, CancellationToken cancellationToken)
        => await _articleCommentRpcWebRequest.InActiveAsync(command, cancellationToken);
}