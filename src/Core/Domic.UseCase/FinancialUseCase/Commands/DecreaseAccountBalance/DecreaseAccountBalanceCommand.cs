using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.FinancialUseCase.DTOs.GRPCs.DecreaseAccountBalance;

namespace Domic.UseCase.FinancialUseCase.Commands.DecreaseAccountBalance;

public class DecreaseAccountBalanceCommand : ICommand<DecreaseAccountBalanceResponse>
{
    public string AccountId { get; set; }
    public long? Value { get; set; }
}