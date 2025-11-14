using Domic.UseCase.SkillUseCase.DTOs.GRPCs.Create;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.SkillUseCase.Commands.Create;

public sealed class CreateCommand : ICommand<CreateResponse>
{
    public string Name { get; set; }
}