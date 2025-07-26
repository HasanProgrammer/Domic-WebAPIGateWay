using Domic.UseCase.UserUseCase.DTOs.GRPCs.ReadAllPaginated;
using Domic.Core.UseCase.Contracts.Abstracts;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Commons.Enumerations;

namespace Domic.UseCase.UserUseCase.Queries.ReadAllPaginated;

public class ReadAllPaginatedQuery : PaginatedQuery, IQuery<ReadAllPaginatedResponse>
{
    public string SearchText  { get; set; }
    public Sort Sort          { get; set; }
}