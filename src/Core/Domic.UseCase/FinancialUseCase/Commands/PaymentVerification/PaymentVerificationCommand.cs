using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.FinancialUseCase.DTOs.GRPCs.PaymentVerification;

namespace Domic.UseCase.FinancialUseCase.Commands.PaymentVerification;

public class PaymentVerificationCommand : ICommand<PaymentVerificationResponse>
{
    public long? Amount { get; set; }
    public string BankGatewaySecretKey { get; set; }
}