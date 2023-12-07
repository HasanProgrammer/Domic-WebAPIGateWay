using Karami.Core.Common.ClassHelpers;
using Karami.UseCase.RoleUseCase.DTOs.ViewModels;

namespace Karami.UseCase.RoleUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponseBody
{
    public PaginatedCollection<RolesViewModel> Roles { get; set; }
}