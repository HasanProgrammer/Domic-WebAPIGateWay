using Domic.Core.UseCase.Contracts.Abstracts;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Commons.Enumerations;
using Domic.UseCase.AggregateBookUseCase.DTOs.GRPCs.ReadAllPaginated;

namespace Domic.UseCase.AggregateBookUseCase.Queries.ReadAllPaginated;

public class ReadAllPaginatedQuery : PaginatedQuery, IQuery<ReadAllPaginatedResponse>
{
    public string SearchText { get; set; }
    public Sort Sort { get; set; }
    public string UserId { get; set; }
}