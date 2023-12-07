using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.UserUseCase.Contracts.Interfaces;
using Karami.UseCase.UserUseCase.DTOs.GRPCs.ReadOne;

namespace Karami.UseCase.UserUseCase.Queries.ReadOne;

public class ReadOneQueryHandler : IQueryHandler<ReadOneQuery, ReadOneResponse>
{
    private readonly IUserRpcWebRequest _userRpcWebRequest;

    public ReadOneQueryHandler(IUserRpcWebRequest userRpcWebRequest) 
        => _userRpcWebRequest = userRpcWebRequest;

    public async Task<ReadOneResponse> HandleAsync(ReadOneQuery query, CancellationToken cancellationToken)
        => await _userRpcWebRequest.ReadOneAsync(query, cancellationToken);
}