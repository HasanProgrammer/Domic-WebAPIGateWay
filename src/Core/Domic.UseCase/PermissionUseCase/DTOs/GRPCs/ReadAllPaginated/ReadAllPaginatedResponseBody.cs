using Domic.UseCase.PermissionUseCase.DTOs.ViewModels;
using Domic.Core.Common.ClassHelpers;

namespace Domic.UseCase.PermissionUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponseBody
{
    public PaginatedCollection<PermissionsViewModel> Permissions { get; set; }
}