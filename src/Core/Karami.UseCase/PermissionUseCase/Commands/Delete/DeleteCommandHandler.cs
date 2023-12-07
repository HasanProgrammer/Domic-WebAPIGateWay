using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.PermissionUseCase.DTOs.GRPCs.Delete;
using Karami.UseCase.RoleUseCase.Contracts.Interfaces;

namespace Karami.UseCase.PermissionUseCase.Commands.Delete;

public class DeleteCommandHandler : ICommandHandler<DeleteCommand, DeleteResponse>
{
    private readonly IPermissionRpcWebRequest _permissionRpcWebRequest;

    public DeleteCommandHandler(IPermissionRpcWebRequest permissionRpcWebRequest) 
        => _permissionRpcWebRequest = permissionRpcWebRequest;

    public async Task<DeleteResponse> HandleAsync(DeleteCommand command, CancellationToken cancellationToken)
        => await _permissionRpcWebRequest.DeleteAsync(command, cancellationToken);
}