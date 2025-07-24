using Domic.Core.Common.ClassHelpers;

namespace Domic.UseCase.ArticleCommentUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponseBody
{
    public PaginatedCollection<ArticleCommentDto> ArticleComments { get; set; }
}