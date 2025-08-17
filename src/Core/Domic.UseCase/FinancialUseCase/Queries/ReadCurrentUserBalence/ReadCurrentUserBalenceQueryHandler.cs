using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.FinancialUseCase.Contracts.Interfaces;

namespace Domic.UseCase.FinancialUseCase.Queries.ReadCurrentUserBalence;

public class ReadCurrentUserBalenceQueryHandler(IFinancialRpcWebRequest financialRpcWebRequest) 
    : IQueryHandler<ReadCurrentUserBalenceQuery, string>
{
    public Task<string> HandleAsync(ReadCurrentUserBalenceQuery query, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}