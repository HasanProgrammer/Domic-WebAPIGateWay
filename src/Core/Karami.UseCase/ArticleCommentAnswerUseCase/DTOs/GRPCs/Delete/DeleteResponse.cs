using Karami.UseCase.Commons.DTOs.GRPCs;

namespace Karami.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.Delete;

public class DeleteResponse : BaseResponse
{
    public DeleteResponseBody Body { get; set; }
}