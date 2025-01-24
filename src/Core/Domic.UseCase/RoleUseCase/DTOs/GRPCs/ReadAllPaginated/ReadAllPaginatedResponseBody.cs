using Domic.Core.Common.ClassHelpers;

namespace Domic.UseCase.RoleUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponseBody
{
    public PaginatedCollection<RoleDto> Roles { get; set; }
}