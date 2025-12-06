using Domic.UseCase.Commons.DTOs.GRPCs;

namespace Domic.UseCase.FinancialUseCase.DTOs.GRPCs.ReadAllTransactionPaginated;

public class CurrentBalenceResponse : BaseResponse
{
    public CurrentBalenceResponseBody Body { get; set; }
}