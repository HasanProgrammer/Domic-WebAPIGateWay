using Karami.UseCase.Commons.DTOs.GRPCs;

namespace Karami.UseCase.RoleUseCase.DTOs.GRPCs.Delete;

public class DeleteResponse : BaseResponse
{
    public DeleteResponseBody Body { get; set; }
}