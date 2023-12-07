using Karami.Core.Common.ClassHelpers;
using Karami.UseCase.ArticleCommentUseCase.DTOs.ViewModels;
using Karami.UseCase.ArticleUseCase.DTOs.ViewModels;

namespace Karami.UseCase.ArticleCommentUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponseBody
{
    public PaginatedCollection<ArticleCommentsViewModel> ArticleComments { get; set; }
}