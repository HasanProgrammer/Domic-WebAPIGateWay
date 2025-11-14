using Domic.UseCase.Commons.DTOs.GRPCs;

namespace Domic.UseCase.SkillUseCase.DTOs.GRPCs.Active;

public class ActiveResponse : BaseResponse
{
    public ActiveResponseBody Body { get; set; }
}