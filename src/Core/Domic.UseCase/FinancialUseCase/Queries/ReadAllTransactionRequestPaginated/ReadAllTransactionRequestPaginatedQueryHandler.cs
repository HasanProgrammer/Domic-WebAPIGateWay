using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.FinancialUseCase.Contracts.Interfaces;
using Domic.UseCase.FinancialUseCase.DTOs.GRPCs.ReadAllPaginated;

namespace Domic.UseCase.FinancialUseCase.Queries.ReadAllTransactionRequest;

public class ReadAllTransactionRequestPaginatedQueryHandler(IFinancialRpcWebRequest financialRpcWebRequest) 
    : IQueryHandler<ReadAllTransactionRequestPaginatedQuery, ReadAllTransactionRequestPaginatedResponse>
{
    [WithValidation]
    public Task<ReadAllTransactionRequestPaginatedResponse> HandleAsync(ReadAllTransactionRequestPaginatedQuery paginatedQuery, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}