using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.RoleUseCase.Contracts.Interfaces;
using Karami.UseCase.RoleUseCase.DTOs.GRPCs.Delete;

namespace Karami.UseCase.RoleUseCase.Commands.SoftDelete;

public class DeleteCommandHandler : ICommandHandler<DeleteCommand, DeleteResponse>
{
    private readonly IRoleRpcWebRequest _roleRpcWebRequest;

    public DeleteCommandHandler(IRoleRpcWebRequest roleRpcWebRequest) 
        => _roleRpcWebRequest = roleRpcWebRequest;

    public async Task<DeleteResponse> HandleAsync(DeleteCommand command, CancellationToken cancellationToken)
        => await _roleRpcWebRequest.DeleteAsync(command, cancellationToken);
}