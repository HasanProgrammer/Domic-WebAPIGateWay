using Domic.Core.Common.ClassHelpers;
using Domic.UseCase.ArticleUseCase.DTOs;

namespace Domic.UseCase.AggregateArticleUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponseBody
{
    public PaginatedCollection<AggregateArticleDto> Articles { get; set; }
}