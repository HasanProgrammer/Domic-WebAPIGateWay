#pragma warning disable CS4014

using Domic.UseCase.CompanyUseCase.DTOs.GRPCs.Create;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.CompanyUseCase.Contracts.Interfaces;

namespace Domic.UseCase.CompanyUseCase.Commands.Create;

public sealed class CreateCommandHandler(ICompanyRpcWebRequest companyRpcWebRequest) : ICommandHandler<CreateCommand, CreateResponse>
{
    public Task BeforeHandleAsync(CreateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    public Task<CreateResponse> HandleAsync(CreateCommand command, CancellationToken cancellationToken) 
        => companyRpcWebRequest.CreateAsync(command, cancellationToken);

    public Task AfterHandleAsync(CreateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}