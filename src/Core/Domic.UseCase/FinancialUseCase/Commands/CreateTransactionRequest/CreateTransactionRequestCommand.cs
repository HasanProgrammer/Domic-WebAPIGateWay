using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.FinancialUseCase.DTOs.GRPCs.CreateTransactionRequest;

namespace Domic.UseCase.FinancialUseCase.Commands.CreateTransactionRequest;

public class CreateTransactionRequestCommand : ICommand<CreateTransactionRequestResponse>
{
    public string AccountId { get; set; }
    public long? Amount { get; set; }
}