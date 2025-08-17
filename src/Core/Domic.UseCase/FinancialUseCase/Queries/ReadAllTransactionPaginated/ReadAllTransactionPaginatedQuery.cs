using Domic.Core.UseCase.Contracts.Abstracts;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Commons.Enumerations;
using Domic.UseCase.FinancialUseCase.DTOs.GRPCs.ReadAllTransactionPaginated;

namespace Domic.UseCase.FinancialUseCase.Queries.ReadAllTransactionPaginated;

public class ReadAllTransactionPaginatedQuery : PaginatedQuery, IQuery<ReadAllTransactionPaginatedResponse>
{
    public string UserId { get; set; }
    public string SearchText { get; set; }
    public Sort Sort { get; set; }
}