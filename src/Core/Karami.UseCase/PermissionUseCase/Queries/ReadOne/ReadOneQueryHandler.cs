using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.PermissionUseCase.DTOs.GRPCs.ReadOne;
using Karami.UseCase.RoleUseCase.Contracts.Interfaces;

namespace Karami.UseCase.PermissionUseCase.Queries.ReadOne;

public class ReadOneQueryHandler : IQueryHandler<ReadOneQuery, ReadOneResponse>
{
    private readonly IPermissionRpcWebRequest _permissionRpcWebRequest;

    public ReadOneQueryHandler(IPermissionRpcWebRequest permissionRpcWebRequest) 
        => _permissionRpcWebRequest = permissionRpcWebRequest;

    public async Task<ReadOneResponse> HandleAsync(ReadOneQuery query, CancellationToken cancellationToken)
        => await _permissionRpcWebRequest.ReadOneAsync(query, cancellationToken);
}