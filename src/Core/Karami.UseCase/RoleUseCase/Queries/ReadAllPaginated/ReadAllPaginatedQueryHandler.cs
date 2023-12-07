using Karami.Core.UseCase.Attributes;
using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.RoleUseCase.Contracts.Interfaces;
using Karami.UseCase.RoleUseCase.DTOs.GRPCs.ReadAllPaginated;

namespace Karami.UseCase.RoleUseCase.Queries.ReadAllPaginated;

public class ReadAllPaginatedQueryHandler : IQueryHandler<ReadAllPaginatedQuery, ReadAllPaginatedResponse>
{
    private readonly IRoleRpcWebRequest _roleRpcWebRequest;

    public ReadAllPaginatedQueryHandler(IRoleRpcWebRequest roleRpcWebRequest) 
        => _roleRpcWebRequest = roleRpcWebRequest;

    [WithValidation]
    public async Task<ReadAllPaginatedResponse> HandleAsync(ReadAllPaginatedQuery query,
        CancellationToken cancellationToken
    ) => await _roleRpcWebRequest.ReadAllPaginatedAsync(query, cancellationToken);
}