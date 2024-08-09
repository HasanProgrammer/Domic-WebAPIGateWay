using Domic.Core.UseCase.Attributes;
using Domic.UseCase.TicketUseCase.Contracts.Interfaces;
using Domic.UseCase.TicketUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace Domic.UseCase.TicketUseCase.Commands.Update;

public class UpdateCommandHandler(ITicketRpcWebRequest TicketRpcWebRequest, IWebHostEnvironment webHostEnvironment) 
    : ICommandHandler<UpdateCommand, UpdateResponse>
{
    [WithValidation]
    public Task<UpdateResponse> HandleAsync(UpdateCommand command, CancellationToken cancellationToken) 
        => TicketRpcWebRequest.UpdateAsync(command, cancellationToken);
}