using Domic.Core.Common.ClassHelpers;

namespace Domic.UseCase.FinancialUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllTransactionRequestPaginatedResponseBody
{
    public PaginatedCollection<TransactionRequestDto> TransactionRequests { get; set; }
}