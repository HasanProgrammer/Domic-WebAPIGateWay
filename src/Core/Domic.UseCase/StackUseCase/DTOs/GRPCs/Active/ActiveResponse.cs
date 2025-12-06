using Domic.UseCase.Commons.DTOs.GRPCs;

namespace Domic.UseCase.StackUseCase.DTOs.GRPCs.Active;

public class ActiveResponse : BaseResponse
{
    public ActiveResponseBody Body { get; set; }
}