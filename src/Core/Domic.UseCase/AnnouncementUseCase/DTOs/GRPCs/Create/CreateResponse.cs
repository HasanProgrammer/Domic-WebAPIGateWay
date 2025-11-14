using Domic.UseCase.Commons.DTOs.GRPCs;

namespace Domic.UseCase.AnnouncementUseCase.DTOs.GRPCs.Create;

public class CreateResponse : BaseResponse
{
    public CreateResponseBody Body { get; set; }
}