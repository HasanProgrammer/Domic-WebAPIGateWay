using Domic.UseCase.ArticleCommentUseCase.DTOs.ViewModels;

namespace Domic.UseCase.ArticleCommentUseCase.DTOs.GRPCs.ReadOne;

public class ReadOneResponseBody
{
    public ArticleCommentsViewModel ArticleComment { get; set; }
}