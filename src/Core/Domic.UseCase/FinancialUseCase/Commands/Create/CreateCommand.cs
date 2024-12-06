using Domic.UseCase.FinancialUseCase.DTOs.GRPCs.Create;
using Domic.Core.UseCase.Contracts.Interfaces;

using TransactionType = Domic.Domain.Enumerations.TransactionType;

namespace Domic.UseCase.FinancialUseCase.Commands.Create;

public class CreateCommand : ICommand<CreateResponse>
{
    public required string AccountId { get; init; }
    public required long? IncreasedAmount { get; init; }
    public required long? DecreasedAmount { get; init; }
    public required TransactionType TransactionType { get; init; }
}