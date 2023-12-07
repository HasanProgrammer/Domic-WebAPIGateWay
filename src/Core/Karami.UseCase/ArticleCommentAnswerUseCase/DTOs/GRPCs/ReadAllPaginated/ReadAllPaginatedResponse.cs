using Karami.UseCase.Commons.DTOs.GRPCs;

namespace Karami.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponse : BaseResponse
{
    public ReadAllPaginatedResponseBody Body { get; set; }
}