using Domic.UseCase.PermissionUseCase.DTOs.GRPCs.ReadAllPaginated;
using Domic.Core.UseCase.Contracts.Abstracts;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.PermissionUseCase.Queries.ReadAllPaginated;

public class ReadAllPaginatedQuery : PaginatedQuery, IQuery<ReadAllPaginatedResponse>
{
    public int Sort          { get; set; }
    public string SearchText { get; set; }
}