using Domic.UseCase.Commons.DTOs.GRPCs;

namespace Domic.UseCase.TicketUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponse : BaseResponse
{
    public ReadAllPaginatedResponseBody Body { get; set; }
}