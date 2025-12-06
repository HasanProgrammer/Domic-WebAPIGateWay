using Domic.UseCase.Commons.DTOs.GRPCs;

namespace Domic.UseCase.FinancialUseCase.DTOs.GRPCs.ReadAllTransactionPaginated;

public class ReadAllTransactionPaginatedResponse : BaseResponse
{
    public ReadAllTransactionPaginatedResponseBody Body { get; set; }
}