using Domic.UseCase.UserUseCase.Contracts.Interfaces;
using Domic.UseCase.UserUseCase.DTOs.GRPCs.Active;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.UserUseCase.Commands.Active;

public class ActiveCommandHandler : ICommandHandler<ActiveCommand, ActiveResponse>
{
    private readonly IUserRpcWebRequest _userRpcWebRequest;

    public ActiveCommandHandler(IUserRpcWebRequest userRpcWebRequest) => _userRpcWebRequest = userRpcWebRequest;

    public Task BeforeHandleAsync(ActiveCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    public Task<ActiveResponse> HandleAsync(ActiveCommand command, CancellationToken cancellationToken)
        => _userRpcWebRequest.ActiveAsync(command, cancellationToken);

    public Task AfterHandleAsync(ActiveCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}