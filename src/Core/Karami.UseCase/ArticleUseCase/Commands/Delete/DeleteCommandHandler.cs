using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.ArticleUseCase.DTOs.GRPCs.Delete;
using Karami.UseCase.RoleUseCase.Contracts.Interfaces;

namespace Karami.UseCase.ArticleUseCase.Commands.Delete;

public class DeleteCommandHandler : ICommandHandler<DeleteCommand, DeleteResponse>
{
    private readonly IArticleRpcWebRequest _articleRpcWebRequest;

    public DeleteCommandHandler(IArticleRpcWebRequest articleRpcWebRequest) 
        => _articleRpcWebRequest = articleRpcWebRequest;

    public async Task<DeleteResponse> HandleAsync(DeleteCommand command, CancellationToken cancellationToken)
        => await _articleRpcWebRequest.DeleteAsync(command, cancellationToken);
}