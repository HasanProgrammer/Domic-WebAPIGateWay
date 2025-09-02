using Domic.Core.Common.ClassHelpers;

namespace Domic.UseCase.SeasonUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponseBody
{
    public PaginatedCollection<SeasonDto> Seasons { get; set; }
}