using Domic.UseCase.Commons.DTOs.GRPCs;

namespace Domic.UseCase.TermUseCase.DTOs.GRPCs.Active;

public class ActiveResponse : BaseResponse
{
    public ActiveResponseBody Body { get; set; }
}