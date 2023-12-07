using Karami.UseCase.Commons.DTOs.GRPCs;

namespace Karami.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.Create;

public class CreateResponse : BaseResponse
{
    public CreateResponseBody Body { get; set; }
}