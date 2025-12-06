using Domic.UseCase.SkillUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.SkillUseCase.Contracts.Interfaces;

namespace Domic.UseCase.SkillUseCase.Commands.Update;

public sealed class UpdateCommandHandler(ISkillRpcWebRequest skillRpcWebRequest) 
    : ICommandHandler<UpdateCommand, UpdateResponse>
{
    public Task BeforeHandleAsync(UpdateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    public Task<UpdateResponse> HandleAsync(UpdateCommand command, CancellationToken cancellationToken) 
        => skillRpcWebRequest.UpdateAsync(command, cancellationToken);

    public Task AfterHandleAsync(UpdateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}