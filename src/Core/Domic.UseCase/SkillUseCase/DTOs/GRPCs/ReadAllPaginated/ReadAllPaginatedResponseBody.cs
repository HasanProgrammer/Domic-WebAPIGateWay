using Domic.Core.Common.ClassHelpers;

namespace Domic.UseCase.SkillUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponseBody
{
    public PaginatedCollection<SkillDto> Skills { get; set; }
}