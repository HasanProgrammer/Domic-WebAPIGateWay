using Domic.UseCase.Commons.DTOs.GRPCs;

namespace Domic.UseCase.AggregateVideoUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponse : BaseResponse
{
    public ReadAllPaginatedResponseBody Body { get; set; }
}