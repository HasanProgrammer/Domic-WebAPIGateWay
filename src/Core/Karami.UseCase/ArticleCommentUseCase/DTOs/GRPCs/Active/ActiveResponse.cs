using Karami.UseCase.Commons.DTOs.GRPCs;

namespace Karami.UseCase.ArticleCommentUseCase.DTOs.GRPCs.Active;

public class ActiveResponse : BaseResponse
{
    public ActiveResponseBody Body { get; set; }
}