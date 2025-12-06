using Domic.Core.Common.ClassHelpers;

namespace Domic.UseCase.AggregateTermCommentUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponseBody
{
    public PaginatedCollection<AggregateCommentDto> Comments { get; set; }
}