using Domic.Core.Common.ClassHelpers;

namespace Domic.UseCase.BookUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponseBody
{
    public PaginatedCollection<BookDto> Books { get; set; }
}