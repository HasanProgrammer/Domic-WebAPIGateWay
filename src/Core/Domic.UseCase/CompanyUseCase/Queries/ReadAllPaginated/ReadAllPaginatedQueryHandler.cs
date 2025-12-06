using Domic.UseCase.CompanyUseCase.DTOs.GRPCs.ReadAllPaginated;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.CompanyUseCase.Contracts.Interfaces;

namespace Domic.UseCase.CompanyUseCase.Queries.ReadAllPaginated;

public class ReadAllPaginatedQueryHandler(ICompanyRpcWebRequest companyRpcWebRequest) 
    : IQueryHandler<ReadAllPaginatedQuery, ReadAllPaginatedResponse>
{
    [WithValidation]
    public Task<ReadAllPaginatedResponse> HandleAsync(ReadAllPaginatedQuery query, CancellationToken cancellationToken) 
        => companyRpcWebRequest.ReadAllPaginatedAsync(query, cancellationToken);
}