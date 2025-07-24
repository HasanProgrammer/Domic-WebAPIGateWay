using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.FinancialUseCase.Contracts.Interfaces;
using Domic.UseCase.FinancialUseCase.DTOs.GRPCs.ChangeStatusTransactionRequest;

namespace Domic.UseCase.FinancialUseCase.Commands.ChangeStatusTransactionRequest;

public class ChangeStatusTransactionRequestCommandHandler(IFinancialRpcWebRequest financialRpcWebRequest) 
    : ICommandHandler<ChangeStatusTransactionRequestCommand, ChangeStatusTransactionRequestResponse>
{
    public Task BeforeHandleAsync(ChangeStatusTransactionRequestCommand command, CancellationToken cancellationToken)
        => Task.CompletedTask;

    public Task<ChangeStatusTransactionRequestResponse> HandleAsync(ChangeStatusTransactionRequestCommand command,
        CancellationToken cancellationToken
    ) => financialRpcWebRequest.ChangeStatusTransactionRequestAsync(command, cancellationToken);

    public Task AfterHandleAsync(ChangeStatusTransactionRequestCommand command, CancellationToken cancellationToken)
        => Task.CompletedTask;
}