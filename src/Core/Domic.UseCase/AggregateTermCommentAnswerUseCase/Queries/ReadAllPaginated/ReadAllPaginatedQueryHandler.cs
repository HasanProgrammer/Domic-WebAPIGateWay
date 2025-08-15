using Domic.UseCase.AggregateTermCommentAnswerUseCase.DTOs.GRPCs.ReadAllPaginated;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.AggregateTermCommentAnswerUseCase.Contracts.Interfaces;

namespace Domic.UseCase.AggregateTermCommentAnswerUseCase.Queries.ReadAllPaginated;

public class ReadAllPaginatedQueryHandler(IAggregateTermCommentAnswerRpcWebRequest aggregateTermCommentAnswerRpcWebRequest) 
    : IQueryHandler<ReadAllPaginatedQuery, ReadAllPaginatedResponse>
{
    [WithValidation]
    public Task<ReadAllPaginatedResponse> HandleAsync(ReadAllPaginatedQuery query, CancellationToken cancellationToken) 
        => aggregateTermCommentAnswerRpcWebRequest.ReadAllPaginatedAsync(query, cancellationToken);
}