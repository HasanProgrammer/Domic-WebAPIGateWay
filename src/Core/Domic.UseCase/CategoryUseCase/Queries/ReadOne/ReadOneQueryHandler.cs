using Domic.UseCase.CategoryUseCase.DTOs.GRPCs.ReadOne;
using Domic.UseCase.RoleUseCase.Contracts.Interfaces;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.CategoryUseCase.Queries.ReadOne;

public class ReadOneQueryHandler : IQueryHandler<ReadOneQuery, ReadOneResponse>
{
    private readonly ICategoryRpcWebRequest _categoryRpcWebRequest;

    public ReadOneQueryHandler(ICategoryRpcWebRequest categoryRpcWebRequest)
        => _categoryRpcWebRequest = categoryRpcWebRequest;

    public Task<ReadOneResponse> HandleAsync(ReadOneQuery query, CancellationToken cancellationToken)
        => _categoryRpcWebRequest.ReadOneAsync(query, cancellationToken);
}