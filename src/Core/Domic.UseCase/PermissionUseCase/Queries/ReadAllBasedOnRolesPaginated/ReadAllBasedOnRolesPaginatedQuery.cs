using Domic.Core.UseCase.Contracts.Abstracts;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.PermissionUseCase.DTOs.GRPCs.ReadAllBasedOnRolesPaginated;

namespace Domic.UseCase.PermissionUseCase.Queries.ReadAllBasedOnRolesPaginated;

public class ReadAllBasedOnRolesPaginatedQuery : PaginatedQuery, IQuery<ReadAllBasedOnRolesPaginatedResponse>
{
    public string Roles { get; set; } //concat with (,)
}