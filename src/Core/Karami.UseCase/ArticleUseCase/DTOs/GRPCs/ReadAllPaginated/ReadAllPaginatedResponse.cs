using Karami.UseCase.Commons.DTOs.GRPCs;

namespace Karami.UseCase.ArticleUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponse : BaseResponse
{
    public ReadAllPaginatedResponseBody Body { get; set; }
}