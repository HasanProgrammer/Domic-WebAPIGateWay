using Domic.UseCase.StackUseCase.DTOs.GRPCs.InActive;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.StackUseCase.Contracts.Interfaces;

namespace Domic.UseCase.StackUseCase.Commands.InActive;

public sealed class InActiveCommandHandler(IStackRpcWebRequest stackRpcWebRequest) 
    : ICommandHandler<InActiveCommand, InActiveResponse>
{
    public Task BeforeHandleAsync(InActiveCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    public Task<InActiveResponse> HandleAsync(InActiveCommand command, CancellationToken cancellationToken)
        => stackRpcWebRequest.InActiveAsync(command, cancellationToken);

    public Task AfterHandleAsync(InActiveCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}