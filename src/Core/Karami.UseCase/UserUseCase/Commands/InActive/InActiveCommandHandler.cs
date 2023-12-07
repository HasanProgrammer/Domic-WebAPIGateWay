using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.UserUseCase.Contracts.Interfaces;
using Karami.UseCase.UserUseCase.DTOs.GRPCs.InActive;

namespace Karami.UseCase.UserUseCase.Commands.InActive;

public class InActiveCommandHandler : ICommandHandler<InActiveCommand, InActiveResponse>
{
    private readonly IUserRpcWebRequest _userRpcWebRequest;

    public InActiveCommandHandler(IUserRpcWebRequest userRpcWebRequest) 
        => _userRpcWebRequest = userRpcWebRequest;

    public async Task<InActiveResponse> HandleAsync(InActiveCommand command, CancellationToken cancellationToken)
        => await _userRpcWebRequest.InActiveAsync(command, cancellationToken);
}