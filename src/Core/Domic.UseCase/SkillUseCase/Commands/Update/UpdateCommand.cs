using Domic.UseCase.SkillUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.SkillUseCase.Commands.Update;

public sealed class UpdateCommand : ICommand<UpdateResponse>
{
    public required string Id { get; set; }
    public required string Name { get; set; }
}