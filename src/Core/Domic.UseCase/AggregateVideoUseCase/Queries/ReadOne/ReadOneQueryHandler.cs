using Domic.UseCase.AggregateVideoUseCase.DTOs.GRPCs.ReadOne;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.AggregateVideoUseCase.Contracts.Interfaces;

namespace Domic.UseCase.AggregateVideoUseCase.Queries.ReadOne;

public class ReadOneQueryHandler(IAggregateVideoRpcWebRequest aggregateVideoRpcWebRequest) 
    : IQueryHandler<ReadOneQuery, ReadOneResponse>
{
    public Task<ReadOneResponse> HandleAsync(ReadOneQuery query, CancellationToken cancellationToken) 
        => aggregateVideoRpcWebRequest.ReadOneAsync(query, cancellationToken);
}