using Domic.Core.Common.ClassHelpers;

namespace Domic.UseCase.AggregateSeasonUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponseBody
{
    public PaginatedCollection<AggregateSeasonDto> Seasons { get; set; }
}