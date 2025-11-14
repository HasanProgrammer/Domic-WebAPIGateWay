using Domic.UseCase.SkillUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.SkillUseCase.Contracts.Interfaces;

namespace Domic.UseCase.SkillUseCase.Commands.Update;

public sealed class DeleteCommandHandler(ISkillRpcWebRequest skillRpcWebRequest) : ICommandHandler<DeleteCommand, DeleteResponse>
{
    public Task BeforeHandleAsync(DeleteCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    public Task<DeleteResponse> HandleAsync(DeleteCommand command, CancellationToken cancellationToken) 
        => skillRpcWebRequest.DeleteAsync(command, cancellationToken);

    public Task AfterHandleAsync(DeleteCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}