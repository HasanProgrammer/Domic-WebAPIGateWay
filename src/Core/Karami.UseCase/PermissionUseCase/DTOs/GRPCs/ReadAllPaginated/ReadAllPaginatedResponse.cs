using Karami.UseCase.Commons.DTOs.GRPCs;

namespace Karami.UseCase.PermissionUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponse : BaseResponse
{
    public ReadAllPaginatedResponseBody Body { get; set; }
}