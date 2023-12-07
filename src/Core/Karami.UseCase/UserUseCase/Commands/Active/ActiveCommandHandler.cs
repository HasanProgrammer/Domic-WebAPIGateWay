using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.UserUseCase.Contracts.Interfaces;
using Karami.UseCase.UserUseCase.DTOs.GRPCs.Active;

namespace Karami.UseCase.UserUseCase.Commands.Active;

public class ActiveCommandHandler : ICommandHandler<ActiveCommand, ActiveResponse>
{
    private readonly IUserRpcWebRequest _userRpcWebRequest;

    public ActiveCommandHandler(IUserRpcWebRequest userRpcWebRequest) 
        => _userRpcWebRequest = userRpcWebRequest;

    public async Task<ActiveResponse> HandleAsync(ActiveCommand command, CancellationToken cancellationToken) 
        => await _userRpcWebRequest.ActiveAsync(command, cancellationToken);
}