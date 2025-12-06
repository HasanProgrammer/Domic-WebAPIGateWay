using Domic.UseCase.Commons.DTOs.GRPCs;

namespace Domic.UseCase.SeasonUseCase.DTOs.GRPCs.ReadAllBasedOnTermId;

public class ReadAllBasedOnTermIdResponse : BaseResponse
{
    public ReadAllBasedOnTermIdResponseBody Body { get; set; }
}