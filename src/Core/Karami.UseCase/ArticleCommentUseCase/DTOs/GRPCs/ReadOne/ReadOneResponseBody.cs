using Karami.UseCase.ArticleCommentUseCase.DTOs.ViewModels;

namespace Karami.UseCase.ArticleCommentUseCase.DTOs.GRPCs.ReadOne;

public class ReadOneResponseBody
{
    public ArticleCommentsViewModel ArticleComment { get; set; }
}