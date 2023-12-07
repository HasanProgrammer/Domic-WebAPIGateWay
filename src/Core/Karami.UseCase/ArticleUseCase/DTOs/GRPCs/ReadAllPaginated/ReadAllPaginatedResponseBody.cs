using Karami.Core.Common.ClassHelpers;
using Karami.UseCase.ArticleUseCase.DTOs.ViewModels;

namespace Karami.UseCase.ArticleUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponseBody
{
    public PaginatedCollection<ArticlesViewModel> Articles { get; set; }
}