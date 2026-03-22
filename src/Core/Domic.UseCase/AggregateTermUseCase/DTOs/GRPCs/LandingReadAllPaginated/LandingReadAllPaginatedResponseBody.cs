using Domic.Core.Common.ClassHelpers;

namespace Domic.UseCase.AggregateTermUseCase.DTOs.GRPCs.LandingReadAllPaginated;

public class LandingReadAllPaginatedResponseBody
{
    public PaginatedCollection<LandingAggregateTermDto> Terms { get; set; }
}