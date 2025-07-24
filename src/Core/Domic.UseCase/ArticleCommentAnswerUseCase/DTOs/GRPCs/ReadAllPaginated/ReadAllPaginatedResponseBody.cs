using Domic.Core.Common.ClassHelpers;

namespace Domic.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponseBody
{
    public PaginatedCollection<ArticleCommentAnswerDto> ArticleCommentAnswers { get; set; }
}