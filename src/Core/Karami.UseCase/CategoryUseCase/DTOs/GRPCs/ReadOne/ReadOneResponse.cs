using Karami.UseCase.Commons.DTOs.GRPCs;

namespace Karami.UseCase.CategoryUseCase.DTOs.GRPCs.ReadOne;

public class ReadOneResponse : BaseResponse
{
    public ReadOneResponseBody Body { get; set; }
}