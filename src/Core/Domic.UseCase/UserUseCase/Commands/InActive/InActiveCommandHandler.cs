using Domic.UseCase.UserUseCase.Contracts.Interfaces;
using Domic.UseCase.UserUseCase.DTOs.GRPCs.InActive;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.UserUseCase.Commands.InActive;

public class InActiveCommandHandler : ICommandHandler<InActiveCommand, InActiveResponse>
{
    private readonly IUserRpcWebRequest _userRpcWebRequest;

    public InActiveCommandHandler(IUserRpcWebRequest userRpcWebRequest) => _userRpcWebRequest = userRpcWebRequest;

    public Task BeforeHandleAsync(InActiveCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    public Task<InActiveResponse> HandleAsync(InActiveCommand command, CancellationToken cancellationToken)
        => _userRpcWebRequest.InActiveAsync(command, cancellationToken);

    public Task AfterHandleAsync(InActiveCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}