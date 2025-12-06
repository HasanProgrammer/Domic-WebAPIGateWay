using Domic.UseCase.AggregateArticleUseCase.DTOs.GRPCs.ReadOne;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.AggregateArticleUseCase.Contracts.Interfaces;

namespace Domic.UseCase.AggregateArticleUseCase.Queries.ReadOne;

public class ReadOneQueryHandler(IAggregateArticleRpcWebRequest aggregateArticleRpcWebRequest) : IQueryHandler<ReadOneQuery, ReadOneResponse>
{
    public Task<ReadOneResponse> HandleAsync(ReadOneQuery query, CancellationToken cancellationToken)
        => aggregateArticleRpcWebRequest.ReadOneAsync(query, cancellationToken);
}