using Domic.Core.UseCase.Contracts.Abstracts;

namespace Domic.WebAPI.DTOs;

public class LandingArticleCurrentUserDto : PaginatedQuery
{
    public required string SearchText { get; set; }
    public required bool IsActive { get; set; }
}