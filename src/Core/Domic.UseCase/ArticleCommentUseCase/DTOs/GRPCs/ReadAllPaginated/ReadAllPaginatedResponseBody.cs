using Domic.Core.Common.ClassHelpers;
using Domic.UseCase.Commons.DTOs;

namespace Domic.UseCase.ArticleCommentUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponseBody
{
    public PaginatedCollection<CommentDto> Comments { get; set; }
}