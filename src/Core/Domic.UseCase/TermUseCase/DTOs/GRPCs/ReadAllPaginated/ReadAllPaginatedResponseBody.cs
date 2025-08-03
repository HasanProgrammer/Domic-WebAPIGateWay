using Domic.Core.Common.ClassHelpers;
using Domic.UseCase.TermUseCase.DTOs;

namespace Domic.UseCase.TermUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponseBody
{
    public PaginatedCollection<TermDto> Terms { get; set; }
}