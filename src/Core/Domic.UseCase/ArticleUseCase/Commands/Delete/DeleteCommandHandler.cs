using Domic.UseCase.ArticleUseCase.DTOs.GRPCs.Delete;
using Domic.UseCase.RoleUseCase.Contracts.Interfaces;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.ArticleUseCase.Commands.Delete;

public class DeleteCommandHandler : ICommandHandler<DeleteCommand, DeleteResponse>
{
    private readonly IArticleRpcWebRequest _articleRpcWebRequest;

    public DeleteCommandHandler(IArticleRpcWebRequest articleRpcWebRequest) 
        => _articleRpcWebRequest = articleRpcWebRequest;

    public Task BeforeHandleAsync(DeleteCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    public Task<DeleteResponse> HandleAsync(DeleteCommand command, CancellationToken cancellationToken)
        => _articleRpcWebRequest.DeleteAsync(command, cancellationToken);

    public Task AfterHandleAsync(DeleteCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}