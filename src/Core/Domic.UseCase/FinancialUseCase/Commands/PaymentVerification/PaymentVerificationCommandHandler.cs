using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.FinancialUseCase.Contracts.Interfaces;
using Domic.UseCase.FinancialUseCase.DTOs.GRPCs.PaymentVerification;

namespace Domic.UseCase.FinancialUseCase.Commands.PaymentVerification;

public class PaymentVerificationCommandHandler(IFinancialRpcWebRequest financialRpcWebRequest) 
    : ICommandHandler<PaymentVerificationCommand, PaymentVerificationResponse>
{
    public Task BeforeHandleAsync(PaymentVerificationCommand command, CancellationToken cancellationToken)
        => Task.CompletedTask;

    public Task<PaymentVerificationResponse> HandleAsync(PaymentVerificationCommand command,
        CancellationToken cancellationToken
    ) => financialRpcWebRequest.PaymentVerificationAsync(command, cancellationToken);

    public Task AfterHandleAsync(PaymentVerificationCommand command, CancellationToken cancellationToken)
        => Task.CompletedTask;
}