using Domic.UseCase.Commons.DTOs.GRPCs;

namespace Domic.UseCase.CampaignUseCase.DTOs.GRPCs.Update;

public class DeleteResponse : BaseResponse
{
    public DeleteResponseBody Body { get; set; }
}