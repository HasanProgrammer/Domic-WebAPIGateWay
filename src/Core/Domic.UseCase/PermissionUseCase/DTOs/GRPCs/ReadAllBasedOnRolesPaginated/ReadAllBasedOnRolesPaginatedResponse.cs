using Domic.UseCase.Commons.DTOs.GRPCs;

namespace Domic.UseCase.PermissionUseCase.DTOs.GRPCs.ReadAllBasedOnRolesPaginated;

public class ReadAllBasedOnRolesPaginatedResponse : BaseResponse
{
    public ReadAllBasedOnRolesPaginatedResponseBody Body { get; set; }
}