using Karami.UseCase.Commons.DTOs.GRPCs;

namespace Karami.UseCase.ArticleUseCase.DTOs.GRPCs.Active;

public class ActiveResponse : BaseResponse
{
    public ActiveResponseBody Body { get; set; }
}