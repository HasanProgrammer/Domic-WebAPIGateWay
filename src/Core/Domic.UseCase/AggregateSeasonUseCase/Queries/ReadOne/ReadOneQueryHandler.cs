using Domic.UseCase.AggregateSeasonUseCase.DTOs.GRPCs.ReadOne;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.AggregateSeasonUseCase.Contracts.Interfaces;

namespace Domic.UseCase.AggregateSeasonUseCase.Queries.ReadOne;

public class ReadOneQueryHandler(IAggregateSeasonRpcWebRequest aggregateSeasonRpcWebRequest) 
    : IQueryHandler<ReadOneQuery, ReadOneResponse>
{
    public Task<ReadOneResponse> HandleAsync(ReadOneQuery query, CancellationToken cancellationToken) 
        => aggregateSeasonRpcWebRequest.ReadOneAsync(query, cancellationToken);
}