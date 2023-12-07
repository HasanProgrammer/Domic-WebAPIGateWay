#pragma warning disable CS4014

using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.Core.UseCase.Attributes;
using Karami.UseCase.ArticleCommentUseCase.Contracts.Interfaces;
using Karami.UseCase.ArticleCommentUseCase.DTOs.GRPCs.Create;

namespace Karami.UseCase.ArticleCommentUseCase.Commands.Create;

public class CreateCommandHandler : ICommandHandler<CreateCommand, CreateResponse>
{
    private readonly IArticleCommentRpcWebRequest _articleCommentRpcWebRequest;

    public CreateCommandHandler(IArticleCommentRpcWebRequest articleCommentRpcWebRequest) 
        => _articleCommentRpcWebRequest = articleCommentRpcWebRequest;

    [WithValidation]
    public async Task<CreateResponse> HandleAsync(CreateCommand command, CancellationToken cancellationToken)
        => await _articleCommentRpcWebRequest.CreateAsync(command, cancellationToken);
}