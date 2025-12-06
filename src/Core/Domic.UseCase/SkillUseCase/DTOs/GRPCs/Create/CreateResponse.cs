using Domic.UseCase.Commons.DTOs.GRPCs;

namespace Domic.UseCase.SkillUseCase.DTOs.GRPCs.Create;

public class CreateResponse : BaseResponse
{
    public CreateResponseBody Body { get; set; }
}