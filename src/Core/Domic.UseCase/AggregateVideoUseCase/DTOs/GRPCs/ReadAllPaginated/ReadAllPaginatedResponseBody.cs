using Domic.Core.Common.ClassHelpers;

namespace Domic.UseCase.AggregateVideoUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponseBody
{
    public PaginatedCollection<AggregateVideosDto> Videos { get; set; }
}