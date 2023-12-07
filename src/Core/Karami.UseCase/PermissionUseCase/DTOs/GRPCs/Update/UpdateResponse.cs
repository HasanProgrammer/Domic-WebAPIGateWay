using Karami.UseCase.Commons.DTOs.GRPCs;

namespace Karami.UseCase.PermissionUseCase.DTOs.GRPCs.Update;

public class UpdateResponse : BaseResponse
{
    public UpdateResponseBody Body { get; set; }
}