using Karami.Core.Common.ClassHelpers;
using Karami.UseCase.PermissionUseCase.DTOs.ViewModels;

namespace Karami.UseCase.PermissionUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponseBody
{
    public PaginatedCollection<PermissionsViewModel> Permissions { get; set; }
}