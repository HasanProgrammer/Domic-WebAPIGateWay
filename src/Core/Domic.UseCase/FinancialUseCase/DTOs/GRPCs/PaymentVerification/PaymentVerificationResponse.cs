using Domic.UseCase.Commons.DTOs.GRPCs;

namespace Domic.UseCase.FinancialUseCase.DTOs.GRPCs.PaymentVerification;

public class PaymentVerificationResponse : BaseResponse
{
    public PaymentVerificationResponseBody Body { get; set; }
}