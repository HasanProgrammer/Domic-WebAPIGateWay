using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.PermissionUseCase.DTOs.GRPCs.Create;
using Karami.UseCase.RoleUseCase.Contracts.Interfaces;

namespace Karami.UseCase.PermissionUseCase.Commands.Create;

public class CreateCommandHandler : ICommandHandler<CreateCommand, CreateResponse>
{
    private readonly IPermissionRpcWebRequest _permissionRpcWebRequest;

    public CreateCommandHandler(IPermissionRpcWebRequest permissionRpcWebRequest) 
        => _permissionRpcWebRequest = permissionRpcWebRequest;

    public async Task<CreateResponse> HandleAsync(CreateCommand command, CancellationToken cancellationToken)
        => await _permissionRpcWebRequest.CreateAsync(command, cancellationToken);
}