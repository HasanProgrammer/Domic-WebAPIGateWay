using Karami.UseCase.Commons.DTOs.GRPCs;

namespace Karami.UseCase.UserUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponse : BaseResponse
{
    public ReadAllPaginatedResponseBody Body { get; set; }
}