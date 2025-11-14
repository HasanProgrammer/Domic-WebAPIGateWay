using Domic.UseCase.SkillUseCase.DTOs.GRPCs.InActive;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.SkillUseCase.Commands.InActive;

public sealed class InActiveCommand : ICommand<InActiveResponse>
{
    public required string Id { get; init; }
}