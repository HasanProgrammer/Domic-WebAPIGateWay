using Domic.UseCase.RoleUseCase.DTOs.ViewModels;
using Domic.Core.Common.ClassHelpers;

namespace Domic.UseCase.RoleUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponseBody
{
    public PaginatedCollection<RolesViewModel> Roles { get; set; }
}