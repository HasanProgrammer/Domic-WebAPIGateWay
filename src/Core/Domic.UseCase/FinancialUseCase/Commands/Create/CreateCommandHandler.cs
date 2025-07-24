#pragma warning disable CS4014

using Domic.UseCase.FinancialUseCase.DTOs.GRPCs.Create;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.FinancialUseCase.Contracts.Interfaces;

namespace Domic.UseCase.FinancialUseCase.Commands.Create;

public class CreateCommandHandler(IFinancialRpcWebRequest financialRpcWebRequest) 
    : ICommandHandler<CreateCommand, CreateResponse>
{
    public Task BeforeHandleAsync(CreateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
    
    public Task<CreateResponse> HandleAsync(CreateCommand command, CancellationToken cancellationToken)
        => financialRpcWebRequest.CreateAsync(command, cancellationToken);

    public Task AfterHandleAsync(CreateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}