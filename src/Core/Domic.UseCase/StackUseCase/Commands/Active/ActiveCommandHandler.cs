using Domic.UseCase.StackUseCase.DTOs.GRPCs.Active;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.StackUseCase.Contracts.Interfaces;

namespace Domic.UseCase.StackUseCase.Commands.Active;

public sealed class ActiveCommandHandler(IStackRpcWebRequest stackRpcWebRequest) : ICommandHandler<ActiveCommand, ActiveResponse>
{
    public Task BeforeHandleAsync(ActiveCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    public Task<ActiveResponse> HandleAsync(ActiveCommand command, CancellationToken cancellationToken) 
        => stackRpcWebRequest.ActiveAsync(command, cancellationToken);

    public Task AfterHandleAsync(ActiveCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}