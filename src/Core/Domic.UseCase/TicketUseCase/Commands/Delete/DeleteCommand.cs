using Domic.UseCase.TicketUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.TicketUseCase.Commands.Update;

public class DeleteCommand : ICommand<DeleteResponse>
{
    public required string TicketId { get; init; }
}