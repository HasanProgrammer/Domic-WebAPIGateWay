using Domic.UseCase.TicketUseCase.DTOs;

namespace Domic.UseCase.TicketUseCase.DTOs.GRPCs.ReadOne;

public class ReadOneResponseBody
{
    public TicketsDto Ticket { get; set; }
}