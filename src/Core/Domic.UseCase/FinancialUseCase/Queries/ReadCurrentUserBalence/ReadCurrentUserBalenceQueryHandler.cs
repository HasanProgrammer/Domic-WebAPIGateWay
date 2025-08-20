using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.FinancialUseCase.Contracts.Interfaces;
using Domic.UseCase.FinancialUseCase.DTOs.GRPCs.ReadAllTransactionPaginated;

namespace Domic.UseCase.FinancialUseCase.Queries.ReadCurrentUserBalence;

public class ReadCurrentUserBalenceQueryHandler(IFinancialRpcWebRequest financialRpcWebRequest) 
    : IQueryHandler<ReadCurrentUserBalenceQuery, CurrentBalenceResponse>
{
    public Task<CurrentBalenceResponse> HandleAsync(ReadCurrentUserBalenceQuery query, CancellationToken cancellationToken)
        => financialRpcWebRequest.CurrentBalenceAsync(query, cancellationToken);
}