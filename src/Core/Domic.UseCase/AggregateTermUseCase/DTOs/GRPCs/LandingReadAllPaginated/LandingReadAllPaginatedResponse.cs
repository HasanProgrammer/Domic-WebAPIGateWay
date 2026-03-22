using Domic.UseCase.Commons.DTOs.GRPCs;

namespace Domic.UseCase.AggregateTermUseCase.DTOs.GRPCs.LandingReadAllPaginated;

public class LandingReadAllPaginatedResponse : BaseResponse
{
    public LandingReadAllPaginatedResponseBody Body { get; set; }
}