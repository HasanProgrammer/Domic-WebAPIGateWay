using Karami.UseCase.Commons.DTOs.GRPCs;

namespace Karami.UseCase.ArticleUseCase.DTOs.GRPCs.InActive;

public class InActiveResponse : BaseResponse
{
    public InActiveResponseBody Body { get; set; }
}