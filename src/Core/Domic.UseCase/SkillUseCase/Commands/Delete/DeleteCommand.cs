using Domic.UseCase.SkillUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.SkillUseCase.Commands.Update;

public sealed class DeleteCommand : ICommand<DeleteResponse>
{
    public string Id { get; set; }
}