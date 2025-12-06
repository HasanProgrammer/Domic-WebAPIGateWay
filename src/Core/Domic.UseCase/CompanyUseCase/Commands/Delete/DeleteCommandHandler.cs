using Domic.UseCase.CompanyUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.CompanyUseCase.Contracts.Interfaces;

namespace Domic.UseCase.CompanyUseCase.Commands.Update;

public sealed class DeleteCommandHandler(ICompanyRpcWebRequest companyRpcWebRequest) : ICommandHandler<DeleteCommand, DeleteResponse>
{
    public Task BeforeHandleAsync(DeleteCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    public Task<DeleteResponse> HandleAsync(DeleteCommand command, CancellationToken cancellationToken) 
        => companyRpcWebRequest.DeleteAsync(command, cancellationToken);

    public Task AfterHandleAsync(DeleteCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}