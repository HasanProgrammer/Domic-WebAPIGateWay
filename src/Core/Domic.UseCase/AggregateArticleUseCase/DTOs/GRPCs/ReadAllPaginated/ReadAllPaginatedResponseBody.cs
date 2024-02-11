using Domic.UseCase.ArticleUseCase.DTOs.ViewModels;
using Domic.Core.Common.ClassHelpers;

namespace Domic.UseCase.AggregateArticleUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponseBody
{
    public PaginatedCollection<AggregateArticlesViewModel> Articles { get; set; }
}