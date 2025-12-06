using Domic.Core.UseCase.Contracts.Abstracts;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Commons.Enumerations;
using Domic.UseCase.FinancialUseCase.DTOs.GRPCs.ReadAllTransactionRequestPaginated;

namespace Domic.UseCase.FinancialUseCase.Queries.ReadAllTransactionRequestPaginated;

public class ReadAllTransactionRequestPaginatedQuery : PaginatedQuery, 
    IQuery<ReadAllTransactionRequestPaginatedResponse>
{
    public string UserId { get; set; }
    public string SearchText { get; set; }
    public Sort Sort { get; set; }
}