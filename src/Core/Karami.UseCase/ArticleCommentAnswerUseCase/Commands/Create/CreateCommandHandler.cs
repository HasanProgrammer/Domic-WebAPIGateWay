#pragma warning disable CS4014

using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.ArticleCommentAnswerUseCase.Contracts.Interfaces;
using Karami.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.Create;

namespace Karami.UseCase.ArticleCommentAnswerUseCase.Commands.Create;

public class CreateCommandHandler : ICommandHandler<CreateCommand, CreateResponse>
{
    private readonly IArticleCommentAnswerRpcWebRequest _articleCommentAnswerRpcWebRequest;

    public CreateCommandHandler(IArticleCommentAnswerRpcWebRequest articleCommentAnswerRpcWebRequest)
        => _articleCommentAnswerRpcWebRequest = articleCommentAnswerRpcWebRequest;
    
    public async Task<CreateResponse> HandleAsync(CreateCommand command, CancellationToken cancellationToken)
        => await _articleCommentAnswerRpcWebRequest.CreateAsync(command, cancellationToken);
}