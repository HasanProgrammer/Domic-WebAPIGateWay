using Domic.Core.Common.ClassHelpers;

namespace Domic.UseCase.PermissionUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponseBody
{
    public PaginatedCollection<PermissionDto> Permissions { get; set; }
}