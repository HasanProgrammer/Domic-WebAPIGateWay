using Domic.Core.Common.ClassHelpers;
using Domic.UseCase.AggregateTermUseCase.DTOs;

namespace Domic.UseCase.AggregateTermUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponseBody
{
    public PaginatedCollection<AggregateTermsDto> Terms { get; set; }
}