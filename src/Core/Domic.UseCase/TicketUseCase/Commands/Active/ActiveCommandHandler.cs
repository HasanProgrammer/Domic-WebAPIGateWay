using Domic.UseCase.TicketUseCase.DTOs.GRPCs.Active;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.TicketUseCase.Contracts.Interfaces;

namespace Domic.UseCase.TicketUseCase.Commands.Active;

public class ActiveCommandHandler(ITicketRpcWebRequest TicketRpcWebRequest) 
    : ICommandHandler<ActiveCommand, ActiveResponse>
{
    public Task<ActiveResponse> HandleAsync(ActiveCommand command, CancellationToken cancellationToken) 
        => TicketRpcWebRequest.ActiveAsync(command, cancellationToken);
}