using Domic.UseCase.Commons.DTOs;

namespace Domic.UseCase.ArticleCommentUseCase.DTOs.GRPCs.ReadOne;

public class ReadOneResponseBody
{
    public CommentDto Comment { get; set; }
}