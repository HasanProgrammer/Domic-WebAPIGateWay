using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.RoleUseCase.Contracts.Interfaces;
using Karami.UseCase.RoleUseCase.DTOs.GRPCs.ReadOne;

namespace Karami.UseCase.RoleUseCase.Queries.ReadOne;

public class ReadOneQueryHandler : IQueryHandler<ReadOneQuery, ReadOneResponse>
{
    private readonly IRoleRpcWebRequest _roleRpcWebRequest;

    public ReadOneQueryHandler(IRoleRpcWebRequest roleRpcWebRequest) 
        => _roleRpcWebRequest = roleRpcWebRequest;

    public async Task<ReadOneResponse> HandleAsync(ReadOneQuery query, CancellationToken cancellationToken)
        => await _roleRpcWebRequest.ReadOneAsync(query, cancellationToken);
}