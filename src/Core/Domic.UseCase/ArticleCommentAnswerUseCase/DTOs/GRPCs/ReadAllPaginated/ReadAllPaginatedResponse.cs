using Domic.UseCase.Commons.DTOs.GRPCs;

namespace Domic.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponse : BaseResponse
{
    public ReadAllPaginatedResponseBody Body { get; set; }
}