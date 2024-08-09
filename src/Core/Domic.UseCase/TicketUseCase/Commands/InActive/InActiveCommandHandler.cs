using Domic.UseCase.TicketUseCase.Contracts.Interfaces;
using Domic.UseCase.TicketUseCase.DTOs.GRPCs.InActive;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.TicketUseCase.Commands.InActive;

public class InActiveCommandHandler(ITicketRpcWebRequest TicketRpcWebRequest) 
    : ICommandHandler<InActiveCommand, InActiveResponse>
{
    public Task<InActiveResponse> HandleAsync(InActiveCommand command, CancellationToken cancellationToken)
        => TicketRpcWebRequest.InActiveAsync(command, cancellationToken);
}