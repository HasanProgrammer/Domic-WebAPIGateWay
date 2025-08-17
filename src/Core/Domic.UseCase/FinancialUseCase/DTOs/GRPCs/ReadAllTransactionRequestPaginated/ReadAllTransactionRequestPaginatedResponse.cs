using Domic.UseCase.Commons.DTOs.GRPCs;

namespace Domic.UseCase.FinancialUseCase.DTOs.GRPCs.ReadAllTransactionRequestPaginated;

public class ReadAllTransactionRequestPaginatedResponse : BaseResponse
{
    public ReadAllTransactionRequestPaginatedResponseBody Body { get; set; }
}