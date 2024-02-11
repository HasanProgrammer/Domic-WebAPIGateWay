using Domic.UseCase.RoleUseCase.Contracts.Interfaces;
using Domic.UseCase.RoleUseCase.DTOs.GRPCs.Create;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.RoleUseCase.Commands.Create;

public class CreateCommandHandler : ICommandHandler<CreateCommand, CreateResponse>
{
    private readonly IRoleRpcWebRequest _roleRpcWebRequest;

    public CreateCommandHandler(IRoleRpcWebRequest roleRpcWebRequest) 
        => _roleRpcWebRequest = roleRpcWebRequest;

    public async Task<CreateResponse> HandleAsync(CreateCommand command, CancellationToken cancellationToken)
        => await _roleRpcWebRequest.CreateAsync(command, cancellationToken);
}