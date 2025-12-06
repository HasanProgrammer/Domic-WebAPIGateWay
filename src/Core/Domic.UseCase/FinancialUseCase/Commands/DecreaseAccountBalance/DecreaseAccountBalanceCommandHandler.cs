#pragma warning disable CS0649 // Field is never assigned to, and will always have its default value

using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.FinancialUseCase.Contracts.Interfaces;
using Domic.UseCase.FinancialUseCase.DTOs.GRPCs.DecreaseAccountBalance;

namespace Domic.UseCase.FinancialUseCase.Commands.DecreaseAccountBalance;

public class DecreaseAccountBalanceCommandHandler(IFinancialRpcWebRequest financialRpcWebRequest) 
    : ICommandHandler<DecreaseAccountBalanceCommand, DecreaseAccountBalanceResponse>
{
    public Task BeforeHandleAsync(DecreaseAccountBalanceCommand command, CancellationToken cancellationToken)
        => Task.CompletedTask;

    public Task<DecreaseAccountBalanceResponse> HandleAsync(DecreaseAccountBalanceCommand command,
        CancellationToken cancellationToken
    ) => financialRpcWebRequest.DecreaseAccountBalanceAsync(command, cancellationToken);

    public Task AfterHandleAsync(DecreaseAccountBalanceCommand command, CancellationToken cancellationToken)
        => Task.CompletedTask;
}