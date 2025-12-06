using Domic.UseCase.CompanyUseCase.DTOs.GRPCs.Active;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.CompanyUseCase.Contracts.Interfaces;

namespace Domic.UseCase.CompanyUseCase.Commands.Active;

public sealed class ActiveCommandHandler(ICompanyRpcWebRequest companyRpcWebRequest) : ICommandHandler<ActiveCommand, ActiveResponse>
{
    public Task BeforeHandleAsync(ActiveCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    public Task<ActiveResponse> HandleAsync(ActiveCommand command, CancellationToken cancellationToken) 
        => companyRpcWebRequest.ActiveAsync(command, cancellationToken);

    public Task AfterHandleAsync(ActiveCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}