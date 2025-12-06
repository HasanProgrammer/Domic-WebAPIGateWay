using Domic.UseCase.Commons.DTOs.GRPCs;

namespace Domic.UseCase.SeasonUseCase.DTOs.GRPCs.Update;

public class DeleteResponse : BaseResponse
{
    public DeleteResponseBody Body { get; set; }
}