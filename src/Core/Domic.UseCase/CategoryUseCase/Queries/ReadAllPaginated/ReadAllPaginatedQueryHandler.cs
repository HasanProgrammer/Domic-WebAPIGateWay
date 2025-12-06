using Domic.UseCase.CategoryUseCase.DTOs.GRPCs.ReadAllPaginated;
using Domic.UseCase.RoleUseCase.Contracts.Interfaces;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.CategoryUseCase.Queries.ReadAllPaginated;

public class ReadAllPaginatedQueryHandler : IQueryHandler<ReadAllPaginatedQuery, ReadAllPaginatedResponse>
{
    private readonly ICategoryRpcWebRequest _categoryRpcWebRequest;

    public ReadAllPaginatedQueryHandler(ICategoryRpcWebRequest categoryRpcWebRequest) 
        => _categoryRpcWebRequest = categoryRpcWebRequest;

    [WithValidation]
    public Task<ReadAllPaginatedResponse> HandleAsync(ReadAllPaginatedQuery query,
        CancellationToken cancellationToken
    ) => _categoryRpcWebRequest.ReadAllPaginatedAsync(query, cancellationToken);
}