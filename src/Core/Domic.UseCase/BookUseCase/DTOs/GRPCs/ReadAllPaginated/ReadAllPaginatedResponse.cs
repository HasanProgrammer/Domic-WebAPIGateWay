using Domic.UseCase.Commons.DTOs.GRPCs;

namespace Domic.UseCase.BookUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponse : BaseResponse
{
    public ReadAllPaginatedResponseBody Body { get; set; }
}