using Domic.UseCase.ArticleCommentAnswerUseCase.DTOs.ViewModels;

namespace Domic.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.ReadOne;

public class ReadOneResponseBody
{
    public ArticleCommentAnswersViewModel ArticleCommentAnswer { get; set; }
}