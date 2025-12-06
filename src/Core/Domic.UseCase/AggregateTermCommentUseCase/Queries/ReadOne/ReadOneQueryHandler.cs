using Domic.UseCase.AggregateTermCommentUseCase.DTOs.GRPCs.ReadOne;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.AggregateTermCommentUseCase.Contracts.Interfaces;

namespace Domic.UseCase.AggregateTermCommentUseCase.Queries.ReadOne;

public class ReadOneQueryHandler(IAggregateTermCommentRpcWebRequest aggregateTermCommentRpcWebRequest) 
    : IQueryHandler<ReadOneQuery, ReadOneResponse>
{
    public Task<ReadOneResponse> HandleAsync(ReadOneQuery query, CancellationToken cancellationToken) 
        => aggregateTermCommentRpcWebRequest.ReadOneAsync(query, cancellationToken);
}