using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.RoleUseCase.Contracts.Interfaces;
using Karami.UseCase.RoleUseCase.DTOs.GRPCs.Create;

namespace Karami.UseCase.RoleUseCase.Commands.Create;

public class CreateCommandHandler : ICommandHandler<CreateCommand, CreateResponse>
{
    private readonly IRoleRpcWebRequest _roleRpcWebRequest;

    public CreateCommandHandler(IRoleRpcWebRequest roleRpcWebRequest) 
        => _roleRpcWebRequest = roleRpcWebRequest;

    public async Task<CreateResponse> HandleAsync(CreateCommand command, CancellationToken cancellationToken)
        => await _roleRpcWebRequest.CreateAsync(command, cancellationToken);
}