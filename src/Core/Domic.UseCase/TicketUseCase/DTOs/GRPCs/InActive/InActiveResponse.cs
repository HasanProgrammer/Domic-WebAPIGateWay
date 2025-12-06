using Domic.UseCase.Commons.DTOs.GRPCs;

namespace Domic.UseCase.TicketUseCase.DTOs.GRPCs.InActive;

public class InActiveResponse : BaseResponse
{
    public InActiveResponseBody Body { get; set; }
}