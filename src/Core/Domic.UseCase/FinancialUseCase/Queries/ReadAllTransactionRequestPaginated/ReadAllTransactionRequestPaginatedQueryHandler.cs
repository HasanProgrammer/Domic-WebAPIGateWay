using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.FinancialUseCase.Contracts.Interfaces;
using Domic.UseCase.FinancialUseCase.DTOs.GRPCs.ReadAllTransactionRequestPaginated;

namespace Domic.UseCase.FinancialUseCase.Queries.ReadAllTransactionRequestPaginated;

public class ReadAllTransactionPaginatedQueryHandler(IFinancialRpcWebRequest financialRpcWebRequest) 
    : IQueryHandler<ReadAllTransactionRequestPaginatedQuery, ReadAllTransactionRequestPaginatedResponse>
{
    [WithValidation]
    public Task<ReadAllTransactionRequestPaginatedResponse> HandleAsync(
        ReadAllTransactionRequestPaginatedQuery query, CancellationToken cancellationToken
    ) => financialRpcWebRequest.ReadAllTransactionRequestPaginatedAsync(query, cancellationToken);
}