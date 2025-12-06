using Domic.UseCase.TermUseCase.DTOs.GRPCs.ReadOne;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.TermUseCase.Contracts.Interfaces;

namespace Domic.UseCase.TermUseCase.Queries.ReadOne;

public class ReadOneQueryHandler(ITermRpcWebRequest termRpcWebRequest) : IQueryHandler<ReadOneQuery, ReadOneResponse>
{
    public Task<ReadOneResponse> HandleAsync(ReadOneQuery query, CancellationToken cancellationToken) 
        => termRpcWebRequest.ReadOneAsync(query, cancellationToken);
}