using Domic.UseCase.Commons.DTOs.GRPCs;

namespace Domic.UseCase.SkillUseCase.DTOs.GRPCs.InActive;

public class InActiveResponse : BaseResponse
{
    public InActiveResponseBody Body { get; set; }
}