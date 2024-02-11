using Domic.UseCase.ArticleCommentUseCase.DTOs.ViewModels;
using Domic.Core.Common.ClassHelpers;
using Domic.UseCase.ArticleUseCase.DTOs.ViewModels;

namespace Domic.UseCase.ArticleCommentUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponseBody
{
    public PaginatedCollection<ArticleCommentsViewModel> ArticleComments { get; set; }
}