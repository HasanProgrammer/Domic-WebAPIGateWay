using Domic.UseCase.SkillUseCase.DTOs.GRPCs.Active;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.SkillUseCase.Commands.Active;

public sealed class ActiveCommand : ICommand<ActiveResponse>
{
    public required string Id { get; init; }
}