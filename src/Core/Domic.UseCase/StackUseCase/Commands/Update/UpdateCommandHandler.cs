using Domic.Core.UseCase.Attributes;
using Domic.UseCase.StackUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.StackUseCase.Contracts.Interfaces;

namespace Domic.UseCase.StackUseCase.Commands.Update;

public sealed class UpdateCommandHandler(IStackRpcWebRequest stackRpcWebRequest) 
    : ICommandHandler<UpdateCommand, UpdateResponse>
{
    public Task BeforeHandleAsync(UpdateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    public Task<UpdateResponse> HandleAsync(UpdateCommand command, CancellationToken cancellationToken) 
        => stackRpcWebRequest.UpdateAsync(command, cancellationToken);

    public Task AfterHandleAsync(UpdateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}