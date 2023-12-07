using Karami.UseCase.Commons.DTOs.GRPCs;

namespace Karami.UseCase.CategoryUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponse : BaseResponse
{
    public ReadAllPaginatedResponseBody Body { get; set; }
}