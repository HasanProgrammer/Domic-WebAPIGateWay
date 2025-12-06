using Domic.UseCase.Commons.DTOs.GRPCs;

namespace Domic.UseCase.AggregateTicketUseCase.DTOs.GRPCs.ReadOne;

public class ReadOneResponse : BaseResponse
{
    public ReadOneResponseBody Body { get; set; }
}