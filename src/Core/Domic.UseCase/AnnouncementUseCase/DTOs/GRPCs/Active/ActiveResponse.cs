using Domic.UseCase.Commons.DTOs.GRPCs;

namespace Domic.UseCase.AnnouncementUseCase.DTOs.GRPCs.Active;

public class ActiveResponse : BaseResponse
{
    public ActiveResponseBody Body { get; set; }
}