using Domic.UseCase.Commons.DTOs.GRPCs;

namespace Domic.UseCase.SeasonUseCase.DTOs.GRPCs.InActive;

public class InActiveResponse : BaseResponse
{
    public InActiveResponseBody Body { get; set; }
}