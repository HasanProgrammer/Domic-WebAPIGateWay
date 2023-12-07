using Karami.UseCase.Commons.DTOs.GRPCs;

namespace Karami.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.Active;

public class ActiveResponse : BaseResponse
{
    public ActiveResponseBody Body { get; set; }
}