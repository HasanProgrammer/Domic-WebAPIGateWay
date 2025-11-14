using Domic.UseCase.SkillUseCase.DTOs.GRPCs.ReadOne;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.SkillUseCase.Queries.ReadOne;

public class ReadOneQuery : IQuery<ReadOneResponse>
{
    public required string Id { get; set; }
}