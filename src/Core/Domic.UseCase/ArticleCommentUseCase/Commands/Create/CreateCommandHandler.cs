#pragma warning disable CS4014

using Domic.UseCase.ArticleCommentUseCase.Contracts.Interfaces;
using Domic.UseCase.ArticleCommentUseCase.DTOs.GRPCs.Create;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Core.UseCase.Attributes;

namespace Domic.UseCase.ArticleCommentUseCase.Commands.Create;

public class CreateCommandHandler : ICommandHandler<CreateCommand, CreateResponse>
{
    private readonly IArticleCommentRpcWebRequest _articleCommentRpcWebRequest;

    public CreateCommandHandler(IArticleCommentRpcWebRequest articleCommentRpcWebRequest) 
        => _articleCommentRpcWebRequest = articleCommentRpcWebRequest;

    [WithValidation]
    public async Task<CreateResponse> HandleAsync(CreateCommand command, CancellationToken cancellationToken)
        => await _articleCommentRpcWebRequest.CreateAsync(command, cancellationToken);
}