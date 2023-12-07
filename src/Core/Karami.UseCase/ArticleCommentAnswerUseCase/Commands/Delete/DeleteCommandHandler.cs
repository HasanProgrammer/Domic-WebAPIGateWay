#pragma warning disable CS4014

using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.ArticleCommentAnswerUseCase.Contracts.Interfaces;
using Karami.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.Delete;

namespace Karami.UseCase.ArticleCommentAnswerUseCase.Commands.Delete;

public class DeleteCommandHandler : ICommandHandler<DeleteCommand, DeleteResponse>
{
    private readonly IArticleCommentAnswerRpcWebRequest _articleCommentAnswerRpcWebRequest;

    public DeleteCommandHandler(IArticleCommentAnswerRpcWebRequest articleCommentAnswerRpcWebRequest)
        => _articleCommentAnswerRpcWebRequest = articleCommentAnswerRpcWebRequest;
    
    public async Task<DeleteResponse> HandleAsync(DeleteCommand command, CancellationToken cancellationToken)
        => await _articleCommentAnswerRpcWebRequest.DeleteAsync(command, cancellationToken);
}