using Domic.UseCase.ArticleCommentAnswerUseCase.DTOs.ViewModels;
using Domic.Core.Common.ClassHelpers;

namespace Domic.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponseBody
{
    public PaginatedCollection<ArticleCommentAnswersViewModel> ArticleCommentAnswers { get; set; }
}