using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.RoleUseCase.Contracts.Interfaces;
using Karami.UseCase.RoleUseCase.DTOs.GRPCs.Update;

namespace Karami.UseCase.RoleUseCase.Commands.Update;

public class UpdateCommandHandler : ICommandHandler<UpdateCommand, UpdateResponse>
{
    private readonly IRoleRpcWebRequest _roleRpcWebRequest;

    public UpdateCommandHandler(IRoleRpcWebRequest roleRpcWebRequest) 
        => _roleRpcWebRequest = roleRpcWebRequest;

    public async Task<UpdateResponse> HandleAsync(UpdateCommand command, CancellationToken cancellationToken)
        => await _roleRpcWebRequest.UpdateAsync(command, cancellationToken);
}