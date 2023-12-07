using Karami.UseCase.Commons.DTOs.GRPCs;

namespace Karami.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.Update;

public class UpdateResponse : BaseResponse
{
    public UpdateResponseBody Body { get; set; }
}