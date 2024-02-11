using Domic.UseCase.RoleUseCase.Contracts.Interfaces;
using Domic.UseCase.RoleUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.RoleUseCase.Commands.Update;

public class UpdateCommandHandler : ICommandHandler<UpdateCommand, UpdateResponse>
{
    private readonly IRoleRpcWebRequest _roleRpcWebRequest;

    public UpdateCommandHandler(IRoleRpcWebRequest roleRpcWebRequest) 
        => _roleRpcWebRequest = roleRpcWebRequest;

    public async Task<UpdateResponse> HandleAsync(UpdateCommand command, CancellationToken cancellationToken)
        => await _roleRpcWebRequest.UpdateAsync(command, cancellationToken);
}