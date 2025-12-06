using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Commons.Enumerations;
using Domic.UseCase.FinancialUseCase.DTOs.GRPCs.ChangeStatusTransactionRequest;

namespace Domic.UseCase.FinancialUseCase.Commands.ChangeStatusTransactionRequest;

public class ChangeStatusTransactionRequestCommand : ICommand<ChangeStatusTransactionRequestResponse>
{
    public string Id { get; set; }
    public TransactionStatus Status { get; set; }
    public string RejectReason { get; set; }
    public string BankTransferReceiptImage { get; set; }
}