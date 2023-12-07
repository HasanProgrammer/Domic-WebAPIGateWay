using Karami.Core.Common.ClassHelpers;
using Karami.UseCase.ArticleUseCase.DTOs.ViewModels;

namespace Karami.UseCase.AggregateArticleUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponseBody
{
    public PaginatedCollection<AggregateArticlesViewModel> Articles { get; set; }
}