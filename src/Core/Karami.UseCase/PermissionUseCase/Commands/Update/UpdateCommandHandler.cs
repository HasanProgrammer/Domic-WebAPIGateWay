using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.PermissionUseCase.DTOs.GRPCs.Update;
using Karami.UseCase.RoleUseCase.Contracts.Interfaces;

namespace Karami.UseCase.PermissionUseCase.Commands.Update;

public class UpdateCommandHandler : ICommandHandler<UpdateCommand, UpdateResponse>
{
    private readonly IPermissionRpcWebRequest _permissionRpcWebRequest;

    public UpdateCommandHandler(IPermissionRpcWebRequest permissionRpcWebRequest) 
        => _permissionRpcWebRequest = permissionRpcWebRequest;

    public async Task<UpdateResponse> HandleAsync(UpdateCommand command, CancellationToken cancellationToken)
        => await _permissionRpcWebRequest.UpdateAsync(command, cancellationToken);
}