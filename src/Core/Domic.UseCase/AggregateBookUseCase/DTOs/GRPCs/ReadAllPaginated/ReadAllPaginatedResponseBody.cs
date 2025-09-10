using Domic.Core.Common.ClassHelpers;

namespace Domic.UseCase.AggregateBookUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponseBody
{
    public PaginatedCollection<AggregateBookDto> Books { get; set; }
}