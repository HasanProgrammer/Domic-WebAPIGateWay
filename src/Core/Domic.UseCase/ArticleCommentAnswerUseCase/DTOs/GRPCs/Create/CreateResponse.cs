using Domic.UseCase.Commons.DTOs.GRPCs;

namespace Domic.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.Create;

public class CreateResponse : BaseResponse
{
    public CreateResponseBody Body { get; set; }
}