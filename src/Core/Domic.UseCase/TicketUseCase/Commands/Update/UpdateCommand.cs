using Domic.UseCase.TicketUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Commons.Enumerations;

namespace Domic.UseCase.TicketUseCase.Commands.Update;

public class UpdateCommand : ICommand<UpdateResponse>
{
    public required string Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required TicketStatus? Status { get; set; }
    public required TicketPriority? Priority { get; set; }
}