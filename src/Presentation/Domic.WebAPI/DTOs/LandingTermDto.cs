using Domic.Core.UseCase.Contracts.Abstracts;

namespace Domic.WebAPI.DTOs;

public class LandingTermDto : PaginatedQuery
{
    public string UserId { get; set; }
    public string SearchText { get; set; }
}