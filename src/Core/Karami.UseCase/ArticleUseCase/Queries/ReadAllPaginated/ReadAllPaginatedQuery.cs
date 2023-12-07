using Karami.Core.UseCase.Contracts.Abstracts;
using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.ArticleUseCase.DTOs.GRPCs.ReadAllPaginated;

namespace Karami.UseCase.ArticleUseCase.Queries.ReadAllPaginated;

public class ReadAllPaginatedQuery : PaginatedQuery, IQuery<ReadAllPaginatedResponse>
{
    
}