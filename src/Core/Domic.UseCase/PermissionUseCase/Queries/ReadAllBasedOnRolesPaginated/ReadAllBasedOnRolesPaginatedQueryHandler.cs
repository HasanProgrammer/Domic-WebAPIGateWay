using Domic.UseCase.RoleUseCase.Contracts.Interfaces;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.PermissionUseCase.DTOs.GRPCs.ReadAllBasedOnRolesPaginated;

namespace Domic.UseCase.PermissionUseCase.Queries.ReadAllBasedOnRolesPaginated;

public class ReadAllBasedOnRolesPaginatedQueryHandler 
    : IQueryHandler<ReadAllBasedOnRolesPaginatedQuery, ReadAllBasedOnRolesPaginatedResponse>
{
    private readonly IPermissionRpcWebRequest _permissionRpcWebRequest;

    public ReadAllBasedOnRolesPaginatedQueryHandler(IPermissionRpcWebRequest permissionRpcWebRequest) 
        => _permissionRpcWebRequest = permissionRpcWebRequest;

    //[WithValidation]
    public Task<ReadAllBasedOnRolesPaginatedResponse> HandleAsync(ReadAllBasedOnRolesPaginatedQuery query,
        CancellationToken cancellationToken
    ) => _permissionRpcWebRequest.ReadAllBasedOnRolesPaginatedAsync(query, cancellationToken);
}