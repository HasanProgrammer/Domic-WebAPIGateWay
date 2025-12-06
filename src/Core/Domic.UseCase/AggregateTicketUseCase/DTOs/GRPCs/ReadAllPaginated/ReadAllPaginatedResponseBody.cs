using Domic.Core.Common.ClassHelpers;

namespace Domic.UseCase.AggregateTicketUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponseBody
{
    public PaginatedCollection<AggregateTicketsDto> Tickets { get; set; }
}