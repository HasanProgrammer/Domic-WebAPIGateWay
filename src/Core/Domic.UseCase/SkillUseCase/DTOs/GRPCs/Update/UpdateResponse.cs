using Domic.UseCase.Commons.DTOs.GRPCs;

namespace Domic.UseCase.SkillUseCase.DTOs.GRPCs.Update;

public class UpdateResponse : BaseResponse
{
    public UpdateResponseBody Body { get; set; }
}