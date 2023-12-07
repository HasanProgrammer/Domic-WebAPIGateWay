using Karami.Core.UseCase.Attributes;
using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.PermissionUseCase.DTOs.GRPCs.ReadAllPaginated;
using Karami.UseCase.RoleUseCase.Contracts.Interfaces;

namespace Karami.UseCase.PermissionUseCase.Queries.ReadAllPaginated;

public class ReadAllPaginatedQueryHandler : IQueryHandler<ReadAllPaginatedQuery, ReadAllPaginatedResponse>
{
    private readonly IPermissionRpcWebRequest _permissionRpcWebRequest;

    public ReadAllPaginatedQueryHandler(IPermissionRpcWebRequest permissionRpcWebRequest) 
        => _permissionRpcWebRequest = permissionRpcWebRequest;

    [WithValidation]
    public async Task<ReadAllPaginatedResponse> HandleAsync(ReadAllPaginatedQuery query,
        CancellationToken cancellationToken
    ) => await _permissionRpcWebRequest.ReadAllPaginatedAsync(query, cancellationToken);
}