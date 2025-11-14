using Domic.UseCase.CompanyUseCase.DTOs.GRPCs.ReadOne;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.CompanyUseCase.Contracts.Interfaces;

namespace Domic.UseCase.CompanyUseCase.Queries.ReadOne;

public class ReadOneQueryHandler(ICompanyRpcWebRequest companyRpcWebRequest) : IQueryHandler<ReadOneQuery, ReadOneResponse>
{
    public Task<ReadOneResponse> HandleAsync(ReadOneQuery query, CancellationToken cancellationToken) 
        => companyRpcWebRequest.ReadOneAsync(query, cancellationToken);
}