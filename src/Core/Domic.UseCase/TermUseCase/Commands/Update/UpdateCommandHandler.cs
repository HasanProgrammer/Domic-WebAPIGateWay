using Domic.Core.UseCase.Attributes;
using Domic.UseCase.TermUseCase.Contracts.Interfaces;
using Domic.UseCase.TermUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace Domic.UseCase.TermUseCase.Commands.Update;

public class UpdateCommandHandler(ITermRpcWebRequest termRpcWebRequest, IWebHostEnvironment webHostEnvironment) 
    : ICommandHandler<UpdateCommand, UpdateResponse>
{
    public Task BeforeHandleAsync(UpdateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    [WithValidation]
    public Task<UpdateResponse> HandleAsync(UpdateCommand command, CancellationToken cancellationToken) 
        => termRpcWebRequest.UpdateAsync(command, cancellationToken);

    public Task AfterHandleAsync(UpdateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}