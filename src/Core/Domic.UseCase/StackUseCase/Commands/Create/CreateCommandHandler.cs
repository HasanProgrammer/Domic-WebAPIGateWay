#pragma warning disable CS4014

using Domic.UseCase.StackUseCase.DTOs.GRPCs.Create;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.StackUseCase.Contracts.Interfaces;

namespace Domic.UseCase.StackUseCase.Commands.Create;

public sealed class CreateCommandHandler(IStackRpcWebRequest stackRpcWebRequest) : ICommandHandler<CreateCommand, CreateResponse>
{
    public Task BeforeHandleAsync(CreateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    public Task<CreateResponse> HandleAsync(CreateCommand command, CancellationToken cancellationToken) 
        => stackRpcWebRequest.CreateAsync(command, cancellationToken);

    public Task AfterHandleAsync(CreateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}