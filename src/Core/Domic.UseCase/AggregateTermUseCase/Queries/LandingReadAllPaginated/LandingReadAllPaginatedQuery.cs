using Domic.Core.UseCase.Contracts.Abstracts;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.AggregateTermUseCase.DTOs.GRPCs.LandingReadAllPaginated;

namespace Domic.UseCase.AggregateTermUseCase.Queries.LandingReadAllPaginated;

public class LandingReadAllPaginatedQuery : PaginatedQuery, IQuery<LandingReadAllPaginatedResponse>
{
    public bool Active { get; set; } = true;
    public string UserId { get; set; }
    public string SearchText { get; set; }
    public int Sort { get; set; }
    public string CategoryId { get; set; }
}