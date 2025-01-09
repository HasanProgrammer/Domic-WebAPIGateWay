using Domic.Core.UseCase.Contracts.Abstracts;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.FinancialUseCase.DTOs.GRPCs.ReadAllPaginated;

namespace Domic.UseCase.FinancialUseCase.Queries.ReadAllTransactionRequest;

public class ReadAllTransactionRequestPaginatedQuery : PaginatedQuery, IQuery<ReadAllTransactionRequestPaginatedResponse>
{
    
}