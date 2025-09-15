using Domic.Core.UseCase.Contracts.Abstracts;
using Domic.Domain.Commons.Enumerations;

namespace Domic.WebAPI.DTOs;

public class LandingTermDto : PaginatedQuery
{
    public Sort Sort { get; set; }
    public string UserId { get; set; }
    public string SearchText { get; set; }
    public string CategoryId { get; set; }
}