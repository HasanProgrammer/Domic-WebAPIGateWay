using Domic.UseCase.Commons.DTOs.GRPCs;

namespace Domic.UseCase.RoleUseCase.DTOs.GRPCs.Delete;

public class DeleteResponse : BaseResponse
{
    public DeleteResponseBody Body { get; set; }
}