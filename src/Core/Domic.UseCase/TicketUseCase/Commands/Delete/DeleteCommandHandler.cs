using Domic.UseCase.TicketUseCase.Contracts.Interfaces;
using Domic.UseCase.TicketUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.TicketUseCase.Commands.Update;

public class DeleteCommandHandler(ITicketRpcWebRequest TicketRpcWebRequest) 
    : ICommandHandler<DeleteCommand, DeleteResponse>
{
    public Task<DeleteResponse> HandleAsync(DeleteCommand command, CancellationToken cancellationToken) 
        => TicketRpcWebRequest.DeleteAsync(command, cancellationToken);
}