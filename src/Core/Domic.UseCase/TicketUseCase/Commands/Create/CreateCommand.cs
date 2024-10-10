using Domic.UseCase.TicketUseCase.DTOs.GRPCs.Create;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Commons.Enumerations;

namespace Domic.UseCase.TicketUseCase.Commands.Create;

public class CreateCommand : ICommand<CreateResponse>
{
    public required string CategoryId { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required TicketStatus? Status { get; set; }
    public required TicketPriority? Priority { get; set; }
}