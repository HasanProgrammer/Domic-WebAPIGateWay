using Domic.UseCase.StackUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.StackUseCase.Contracts.Interfaces;

namespace Domic.UseCase.StackUseCase.Commands.Update;

public sealed class DeleteCommandHandler(IStackRpcWebRequest stackRpcWebRequest) : ICommandHandler<DeleteCommand, DeleteResponse>
{
    public Task BeforeHandleAsync(DeleteCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    public Task<DeleteResponse> HandleAsync(DeleteCommand command, CancellationToken cancellationToken) 
        => stackRpcWebRequest.DeleteAsync(command, cancellationToken);

    public Task AfterHandleAsync(DeleteCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}