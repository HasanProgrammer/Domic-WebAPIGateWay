using Karami.Core.UseCase.Contracts.Abstracts;
using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.UserUseCase.DTOs.GRPCs.ReadAllPaginated;

namespace Karami.UseCase.UserUseCase.Queries.ReadAllPaginated;

public class ReadAllPaginatedQuery : PaginatedQuery, IQuery<ReadAllPaginatedResponse>
{
    
}