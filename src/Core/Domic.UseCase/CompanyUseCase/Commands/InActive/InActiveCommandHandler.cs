using Domic.UseCase.CompanyUseCase.DTOs.GRPCs.InActive;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.CompanyUseCase.Contracts.Interfaces;

namespace Domic.UseCase.CompanyUseCase.Commands.InActive;

public sealed class InActiveCommandHandler(ICompanyRpcWebRequest companyRpcWebRequest) 
    : ICommandHandler<InActiveCommand, InActiveResponse>
{
    public Task BeforeHandleAsync(InActiveCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    public Task<InActiveResponse> HandleAsync(InActiveCommand command, CancellationToken cancellationToken)
        => companyRpcWebRequest.InActiveAsync(command, cancellationToken);

    public Task AfterHandleAsync(InActiveCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}