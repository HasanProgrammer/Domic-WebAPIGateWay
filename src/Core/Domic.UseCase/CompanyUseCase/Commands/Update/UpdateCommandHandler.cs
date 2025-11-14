using Domic.UseCase.CompanyUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.CompanyUseCase.Contracts.Interfaces;

namespace Domic.UseCase.CompanyUseCase.Commands.Update;

public sealed class UpdateCommandHandler(ICompanyRpcWebRequest companyRpcWebRequest) 
    : ICommandHandler<UpdateCommand, UpdateResponse>
{
    public Task BeforeHandleAsync(UpdateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    public Task<UpdateResponse> HandleAsync(UpdateCommand command, CancellationToken cancellationToken) 
        => companyRpcWebRequest.UpdateAsync(command, cancellationToken);

    public Task AfterHandleAsync(UpdateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}