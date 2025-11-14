using Domic.UseCase.SkillUseCase.DTOs.GRPCs.Active;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.SkillUseCase.Contracts.Interfaces;

namespace Domic.UseCase.SkillUseCase.Commands.Active;

public sealed class ActiveCommandHandler(ISkillRpcWebRequest skillRpcWebRequest) : ICommandHandler<ActiveCommand, ActiveResponse>
{
    public Task BeforeHandleAsync(ActiveCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    public Task<ActiveResponse> HandleAsync(ActiveCommand command, CancellationToken cancellationToken) 
        => skillRpcWebRequest.ActiveAsync(command, cancellationToken);

    public Task AfterHandleAsync(ActiveCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}