using Karami.Core.UseCase.Contracts.Abstracts;
using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.PermissionUseCase.DTOs.GRPCs.ReadAllPaginated;

namespace Karami.UseCase.PermissionUseCase.Queries.ReadAllPaginated;

public class ReadAllPaginatedQuery : PaginatedQuery, IQuery<ReadAllPaginatedResponse>
{
    
}