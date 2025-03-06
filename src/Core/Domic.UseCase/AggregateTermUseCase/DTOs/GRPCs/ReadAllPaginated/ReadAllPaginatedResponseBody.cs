using Domic.Core.Common.ClassHelpers;

namespace Domic.UseCase.AggregateTermUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponseBody
{
    public PaginatedCollection<AggregateTermDto> Terms { get; set; }
}