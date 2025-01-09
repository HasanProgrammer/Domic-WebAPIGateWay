using Domic.UseCase.Commons.DTOs.GRPCs;

namespace Domic.UseCase.FinancialUseCase.DTOs.GRPCs.DecreaseAccountBalance;

public class DecreaseAccountBalanceResponse : BaseResponse
{
    public DecreaseAccountBalanceResponseBody Body { get; set; }
}