using Karami.UseCase.Commons.DTOs.GRPCs;

namespace Karami.UseCase.ArticleCommentUseCase.DTOs.GRPCs.InActive;

public class InActiveResponse : BaseResponse
{
    public InActiveResponseBody Body { get; set; }
}