using Karami.UseCase.Commons.DTOs.GRPCs;

namespace Karami.UseCase.AggregateArticleUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponse : BaseResponse
{
    public ReadAllPaginatedResponseBody Body { get; set; }
}