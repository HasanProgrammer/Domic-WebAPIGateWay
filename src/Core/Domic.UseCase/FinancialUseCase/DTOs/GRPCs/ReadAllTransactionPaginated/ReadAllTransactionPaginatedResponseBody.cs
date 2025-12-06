using Domic.Core.Common.ClassHelpers;

namespace Domic.UseCase.FinancialUseCase.DTOs.GRPCs.ReadAllTransactionPaginated;

public class ReadAllTransactionPaginatedResponseBody
{
    public PaginatedCollection<TransactionDto> Transactions { get; set; }
}