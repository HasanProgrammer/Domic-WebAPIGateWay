using Karami.UseCase.Commons.DTOs.GRPCs;

namespace Karami.UseCase.RoleUseCase.DTOs.GRPCs.Update;

public class UpdateResponse : BaseResponse
{
    public UpdateResponseBody Body { get; set; }
}