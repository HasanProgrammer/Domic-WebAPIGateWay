using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.FinancialUseCase.Contracts.Interfaces;
using Domic.UseCase.FinancialUseCase.DTOs.GRPCs.CreateTransactionRequest;

namespace Domic.UseCase.FinancialUseCase.Commands.CreateTransactionRequest;

public class CreateTransactionRequestCommandHandler(IFinancialRpcWebRequest financialRpcWebRequest) 
    : ICommandHandler<CreateTransactionRequestCommand, CreateTransactionRequestResponse>
{
    public Task BeforeHandleAsync(CreateTransactionRequestCommand command, CancellationToken cancellationToken)
        => Task.CompletedTask;

    public Task<CreateTransactionRequestResponse> HandleAsync(CreateTransactionRequestCommand command,
        CancellationToken cancellationToken
    ) => financialRpcWebRequest.CreateTransactionRequestAsync(command, cancellationToken);

    public Task AfterHandleAsync(CreateTransactionRequestCommand command, CancellationToken cancellationToken)
        => Task.CompletedTask;
}