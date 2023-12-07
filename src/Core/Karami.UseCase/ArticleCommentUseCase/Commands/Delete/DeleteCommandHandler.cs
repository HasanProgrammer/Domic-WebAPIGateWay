#pragma warning disable CS4014

using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.ArticleCommentUseCase.Contracts.Interfaces;
using Karami.UseCase.ArticleCommentUseCase.DTOs.GRPCs.Delete;

namespace Karami.UseCase.ArticleCommentUseCase.Commands.Delete;

public class DeleteCommandHandler : ICommandHandler<DeleteCommand, DeleteResponse>
{
    private readonly IArticleCommentRpcWebRequest _articleCommentRpcWebRequest;

    public DeleteCommandHandler(IArticleCommentRpcWebRequest articleCommentRpcWebRequest)
        => _articleCommentRpcWebRequest = articleCommentRpcWebRequest;

    public async Task<DeleteResponse> HandleAsync(DeleteCommand command, CancellationToken cancellationToken)
        => await _articleCommentRpcWebRequest.DeleteAsync(command, cancellationToken);
}