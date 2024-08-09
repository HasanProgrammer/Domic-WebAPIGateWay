#pragma warning disable CS4014

using Domic.Core.UseCase.Attributes;
using Domic.UseCase.TicketUseCase.Contracts.Interfaces;
using Domic.UseCase.TicketUseCase.DTOs.GRPCs.Create;
using Domic.Core.UseCase.Contracts.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace Domic.UseCase.TicketUseCase.Commands.Create;

public class CreateCommandHandler(ITicketRpcWebRequest TicketRpcWebRequest, IWebHostEnvironment webHostEnvironment) 
    : ICommandHandler<CreateCommand, CreateResponse>
{
    [WithValidation]
    public Task<CreateResponse> HandleAsync(CreateCommand command, CancellationToken cancellationToken)
        => TicketRpcWebRequest.CreateAsync(command, cancellationToken);
}