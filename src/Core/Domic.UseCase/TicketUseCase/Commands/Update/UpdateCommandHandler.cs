using Domic.Core.UseCase.Attributes;
using Domic.UseCase.TicketUseCase.Contracts.Interfaces;
using Domic.UseCase.TicketUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.TicketUseCase.Commands.Update;

public class UpdateCommandHandler(ITicketRpcWebRequest TicketRpcWebRequest) 
    : ICommandHandler<UpdateCommand, UpdateResponse>
{
    [WithValidation]
    public Task<UpdateResponse> HandleAsync(UpdateCommand command, CancellationToken cancellationToken) 
        => TicketRpcWebRequest.UpdateAsync(command, cancellationToken);
}