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

    public Task BeforeHandleAsync(CreateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    [WithValidation]
    public Task<CreateResponse> HandleAsync(CreateCommand command, CancellationToken cancellationToken)
        => _articleCommentRpcWebRequest.CreateAsync(command, cancellationToken);

    public Task AfterHandleAsync(CreateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}