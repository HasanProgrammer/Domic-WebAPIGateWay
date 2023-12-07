#pragma warning disable CS4014

using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.ArticleCommentAnswerUseCase.Contracts.Interfaces;
using Karami.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.Update;

namespace Karami.UseCase.ArticleCommentAnswerUseCase.Commands.Update;

public class UpdateCommandHandler : ICommandHandler<UpdateCommand, UpdateResponse>
{
    private readonly IArticleCommentAnswerRpcWebRequest _articleCommentAnswerRpcWebRequest;

    public UpdateCommandHandler(IArticleCommentAnswerRpcWebRequest articleCommentAnswerRpcWebRequest)
        => _articleCommentAnswerRpcWebRequest = articleCommentAnswerRpcWebRequest;
    
    public async Task<UpdateResponse> HandleAsync(UpdateCommand command, CancellationToken cancellationToken)
        => await _articleCommentAnswerRpcWebRequest.UpdateAsync(command, cancellationToken);
}