using Domic.UseCase.TicketUseCase.DTOs.GRPCs.Active;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.TicketUseCase.Commands.Active;

public class ActiveCommand : ICommand<ActiveResponse>
{
    public required string TicketId { get; init; }
}