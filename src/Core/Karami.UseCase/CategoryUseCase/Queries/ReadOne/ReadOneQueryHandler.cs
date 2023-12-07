using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.CategoryUseCase.DTOs.GRPCs.ReadOne;
using Karami.UseCase.RoleUseCase.Contracts.Interfaces;

namespace Karami.UseCase.CategoryUseCase.Queries.ReadOne;

public class ReadOneQueryHandler : IQueryHandler<ReadOneQuery, ReadOneResponse>
{
    private readonly ICategoryRpcWebRequest _categoryRpcWebRequest;

    public ReadOneQueryHandler(ICategoryRpcWebRequest categoryRpcWebRequest)
        => _categoryRpcWebRequest = categoryRpcWebRequest;

    public async Task<ReadOneResponse> HandleAsync(ReadOneQuery query, CancellationToken cancellationToken)
        => await _categoryRpcWebRequest.ReadOneAsync(query, cancellationToken);
}