using Domic.UseCase.AggregateTermUseCase.DTOs.GRPCs.ReadAllPaginated;
using Domic.Core.UseCase.Contracts.Abstracts;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.AggregateTermUseCase.Queries.ReadAllPaginated;

public class ReadAllPaginatedQuery : PaginatedQuery, IQuery<ReadAllPaginatedResponse>
{
    public bool Active { get; set; } = true;
    public string UserId { get; set; }
    public string SearchText { get; set; }
    public int Sort { get; set; }
}