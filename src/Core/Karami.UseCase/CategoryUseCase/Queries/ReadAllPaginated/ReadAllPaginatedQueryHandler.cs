using Karami.Core.UseCase.Attributes;
using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.CategoryUseCase.DTOs.GRPCs.ReadAllPaginated;
using Karami.UseCase.RoleUseCase.Contracts.Interfaces;

namespace Karami.UseCase.CategoryUseCase.Queries.ReadAllPaginated;

public class ReadAllPaginatedQueryHandler : IQueryHandler<ReadAllPaginatedQuery, ReadAllPaginatedResponse>
{
    private readonly ICategoryRpcWebRequest _categoryRpcWebRequest;

    public ReadAllPaginatedQueryHandler(ICategoryRpcWebRequest categoryRpcWebRequest) 
        => _categoryRpcWebRequest = categoryRpcWebRequest;

    [WithValidation]
    public async Task<ReadAllPaginatedResponse> HandleAsync(ReadAllPaginatedQuery query,
        CancellationToken cancellationToken
    ) => await _categoryRpcWebRequest.ReadAllPaginatedAsync(query, cancellationToken);
}