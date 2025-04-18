using Domic.Core.UseCase.Contracts.Abstracts;

namespace Domic.WebAPI.DTOs;

public class LandingArticleDto : PaginatedQuery
{
    public required string UserId { get; set; }
    public required string SearchText { get; set; }
}