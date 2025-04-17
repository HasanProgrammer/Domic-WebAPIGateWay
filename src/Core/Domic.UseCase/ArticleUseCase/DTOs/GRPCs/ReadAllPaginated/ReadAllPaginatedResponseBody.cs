using Domic.Core.Common.ClassHelpers;

namespace Domic.UseCase.ArticleUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponseBody
{
    public PaginatedCollection<ArticleDto> Articles { get; set; }
}