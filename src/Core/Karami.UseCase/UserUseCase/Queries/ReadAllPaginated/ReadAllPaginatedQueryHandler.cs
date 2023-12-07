using Karami.Core.UseCase.Attributes;
using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.UserUseCase.Contracts.Interfaces;
using Karami.UseCase.UserUseCase.DTOs.GRPCs.ReadAllPaginated;

namespace Karami.UseCase.UserUseCase.Queries.ReadAllPaginated;

public class ReadAllPaginatedQueryHandler : IQueryHandler<ReadAllPaginatedQuery, ReadAllPaginatedResponse>
{
    private readonly IUserRpcWebRequest _userRpcWebRequest;

    public ReadAllPaginatedQueryHandler(IUserRpcWebRequest userRpcWebRequest) 
        => _userRpcWebRequest = userRpcWebRequest;

    [WithValidation]
    public async Task<ReadAllPaginatedResponse> HandleAsync(ReadAllPaginatedQuery query,
        CancellationToken cancellationToken
    ) => await _userRpcWebRequest.ReadAllPaginatedAsync(query, cancellationToken);
}