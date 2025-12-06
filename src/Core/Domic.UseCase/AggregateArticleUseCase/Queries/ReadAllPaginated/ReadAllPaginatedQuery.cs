using Domic.UseCase.AggregateArticleUseCase.DTOs.GRPCs.ReadAllPaginated;
using Domic.Core.UseCase.Contracts.Abstracts;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.AggregateArticleUseCase.Queries.ReadAllPaginated;

public class ReadAllPaginatedQuery : PaginatedQuery, IQuery<ReadAllPaginatedResponse>
{
    public required string UserId { get; set; }
    public required string SearchText { get; set; }
    public required bool IsActive { get; set; } = true;
}