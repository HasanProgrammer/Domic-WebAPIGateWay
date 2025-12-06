using Domic.UseCase.AggregateTermCommentAnswerUseCase.DTOs.GRPCs.ReadOne;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.AggregateTermCommentAnswerUseCase.Contracts.Interfaces;

namespace Domic.UseCase.AggregateTermCommentAnswerUseCase.Queries.ReadOne;

public class ReadOneQueryHandler(IAggregateTermCommentAnswerRpcWebRequest aggregateTermCommentAnswerRpcWebRequest) 
    : IQueryHandler<ReadOneQuery, ReadOneResponse>
{
    public Task<ReadOneResponse> HandleAsync(ReadOneQuery query, CancellationToken cancellationToken) 
        => aggregateTermCommentAnswerRpcWebRequest.ReadOneAsync(query, cancellationToken);
}