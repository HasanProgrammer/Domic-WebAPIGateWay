using Domic.UseCase.PermissionUseCase.DTOs.GRPCs.ReadOne;
using Domic.UseCase.RoleUseCase.Contracts.Interfaces;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.PermissionUseCase.Queries.ReadOne;

public class ReadOneQueryHandler : IQueryHandler<ReadOneQuery, ReadOneResponse>
{
    private readonly IPermissionRpcWebRequest _permissionRpcWebRequest;

    public ReadOneQueryHandler(IPermissionRpcWebRequest permissionRpcWebRequest) 
        => _permissionRpcWebRequest = permissionRpcWebRequest;

    public Task<ReadOneResponse> HandleAsync(ReadOneQuery query, CancellationToken cancellationToken)
        => _permissionRpcWebRequest.ReadOneAsync(query, cancellationToken);
}