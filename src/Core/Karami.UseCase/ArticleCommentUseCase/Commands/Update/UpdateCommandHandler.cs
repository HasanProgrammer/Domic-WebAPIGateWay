#pragma warning disable CS4014

using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.ArticleCommentUseCase.Contracts.Interfaces;
using Karami.UseCase.ArticleCommentUseCase.DTOs.GRPCs.Update;

namespace Karami.UseCase.ArticleCommentUseCase.Commands.Update;

public class UpdateCommandHandler : ICommandHandler<UpdateCommand, UpdateResponse>
{
    private readonly IArticleCommentRpcWebRequest _articleCommentRpcWebRequest;

    public UpdateCommandHandler(IArticleCommentRpcWebRequest articleCommentRpcWebRequest)
        => _articleCommentRpcWebRequest = articleCommentRpcWebRequest;

    public async Task<UpdateResponse> HandleAsync(UpdateCommand command, CancellationToken cancellationToken)
        => await _articleCommentRpcWebRequest.UpdateAsync(command, cancellationToken);
}