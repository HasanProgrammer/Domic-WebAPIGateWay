using Karami.Core.UseCase.Contracts.Abstracts;
using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.RoleUseCase.DTOs.GRPCs.ReadAllPaginated;

namespace Karami.UseCase.RoleUseCase.Queries.ReadAllPaginated;

public class ReadAllPaginatedQuery : PaginatedQuery, IQuery<ReadAllPaginatedResponse>
{
    
}