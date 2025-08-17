using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.FinancialUseCase.Contracts.Interfaces;
using Domic.UseCase.FinancialUseCase.DTOs.GRPCs.ReadAllTransactionPaginated;

namespace Domic.UseCase.FinancialUseCase.Queries.ReadAllTransactionPaginated;

public class ReadAllTransactionPaginatedQueryHandler(IFinancialRpcWebRequest financialRpcWebRequest) 
    : IQueryHandler<ReadAllTransactionPaginatedQuery, ReadAllTransactionPaginatedResponse>
{
    [WithValidation]
    public Task<ReadAllTransactionPaginatedResponse> HandleAsync(ReadAllTransactionPaginatedQuery query,
        CancellationToken cancellationToken
    ) => financialRpcWebRequest.ReadAllTransactionPaginatedAsync(query, cancellationToken);
}