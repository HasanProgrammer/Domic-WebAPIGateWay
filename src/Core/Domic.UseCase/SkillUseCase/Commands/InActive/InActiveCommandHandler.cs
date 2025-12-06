using Domic.UseCase.SkillUseCase.DTOs.GRPCs.InActive;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.SkillUseCase.Contracts.Interfaces;

namespace Domic.UseCase.SkillUseCase.Commands.InActive;

public sealed class InActiveCommandHandler(ISkillRpcWebRequest skillRpcWebRequest) 
    : ICommandHandler<InActiveCommand, InActiveResponse>
{
    public Task BeforeHandleAsync(InActiveCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    public Task<InActiveResponse> HandleAsync(InActiveCommand command, CancellationToken cancellationToken)
        => skillRpcWebRequest.InActiveAsync(command, cancellationToken);

    public Task AfterHandleAsync(InActiveCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}