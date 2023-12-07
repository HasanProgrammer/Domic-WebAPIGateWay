using Karami.Core.Common.ClassHelpers;
using Karami.UseCase.ArticleCommentAnswerUseCase.DTOs.ViewModels;

namespace Karami.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponseBody
{
    public PaginatedCollection<ArticleCommentAnswersViewModel> ArticleCommentAnswers { get; set; }
}