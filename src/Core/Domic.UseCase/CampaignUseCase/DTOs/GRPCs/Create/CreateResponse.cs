using Domic.UseCase.Commons.DTOs.GRPCs;

namespace Domic.UseCase.CampaignUseCase.DTOs.GRPCs.Create;

public class CreateResponse : BaseResponse
{
    public CreateResponseBody Body { get; set; }
}