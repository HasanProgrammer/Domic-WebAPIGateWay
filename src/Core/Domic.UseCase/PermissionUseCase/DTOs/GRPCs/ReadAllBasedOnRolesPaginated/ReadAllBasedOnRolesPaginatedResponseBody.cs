using Domic.Core.Common.ClassHelpers;

namespace Domic.UseCase.PermissionUseCase.DTOs.GRPCs.ReadAllBasedOnRolesPaginated;

public class ReadAllBasedOnRolesPaginatedResponseBody
{
    public PaginatedCollection<PermissionDto> Permissions { get; set; }
}