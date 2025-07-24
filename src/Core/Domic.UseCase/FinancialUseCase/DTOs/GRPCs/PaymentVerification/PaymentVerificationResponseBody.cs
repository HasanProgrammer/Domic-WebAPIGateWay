namespace Domic.UseCase.FinancialUseCase.DTOs.GRPCs.PaymentVerification;

public class PaymentVerificationResponseBody
{
    public bool Status { get; set; }
    public string TransactionNumber { get; set; }
}