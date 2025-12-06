using Domic.Core.Common.ClassHelpers;

namespace Domic.UseCase.AggregateTermCommentAnswerUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponseBody
{
    public PaginatedCollection<AggregateCommentAnswerDto> Answers { get; set; }
}