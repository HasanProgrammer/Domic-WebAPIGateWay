using Domic.UseCase.CampaignUseCase.DTOs.GRPCs.Update;
using Domic.UseCase.Commons.DTOs.GRPCs;

namespace Domic.UseCase.CampaignUseCase.DTOs.GRPCs.Delete;

public class DeleteResponse : BaseResponse
{
    public DeleteResponseBody Body { get; set; }
}