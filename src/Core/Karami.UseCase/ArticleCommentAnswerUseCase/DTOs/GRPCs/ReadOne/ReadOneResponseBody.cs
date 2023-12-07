using Karami.UseCase.ArticleCommentAnswerUseCase.DTOs.ViewModels;

namespace Karami.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.ReadOne;

public class ReadOneResponseBody
{
    public ArticleCommentAnswersViewModel ArticleCommentAnswer { get; set; }
}