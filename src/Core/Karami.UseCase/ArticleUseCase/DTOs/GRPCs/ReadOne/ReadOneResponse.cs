using Karami.UseCase.Commons.DTOs.GRPCs;

namespace Karami.UseCase.ArticleUseCase.DTOs.GRPCs.ReadOne;

public class ReadOneResponse : BaseResponse
{
    public ReadOneResponseBody Body { get; set; }
}