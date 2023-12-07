using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.CategoryUseCase.DTOs.GRPCs.Delete;
using Karami.UseCase.RoleUseCase.Contracts.Interfaces;

namespace Karami.UseCase.CategoryUseCase.Commands.Delete;

public class DeleteCommandHandler : ICommandHandler<DeleteCommand, DeleteResponse>
{
    private readonly ICategoryRpcWebRequest _categoryRpcWebRequest;

    public DeleteCommandHandler(ICategoryRpcWebRequest categoryRpcWebRequest) 
        => _categoryRpcWebRequest = categoryRpcWebRequest;

    public async Task<DeleteResponse> HandleAsync(DeleteCommand command, CancellationToken cancellationToken)
        => await _categoryRpcWebRequest.DeleteAsync(command, cancellationToken);
}