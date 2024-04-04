using Domic.UseCase.AggregateTermUseCase.DTOs.GRPCs.ReadOne;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.AggregateTermUseCase.Contracts.Interfaces;

namespace Domic.UseCase.AggregateTermUseCase.Queries.ReadOne;

public class ReadOneQueryHandler(IAggregateTermRpcWebRequest aggregateTermRpcWebRequest) 
    : IQueryHandler<ReadOneQuery, ReadOneResponse>
{
    public Task<ReadOneResponse> HandleAsync(ReadOneQuery query, CancellationToken cancellationToken) 
        => aggregateTermRpcWebRequest.ReadOneAsync(query, cancellationToken);
}