using Domic.UseCase.AggregateTermCommentUseCase.DTOs.GRPCs.ReadAllPaginated;
using Domic.UseCase.AggregateTermCommentUseCase.Contracts.Interfaces;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.AggregateTermCommentUseCase.Queries.ReadAllPaginated;

public class ReadAllPaginatedQueryHandler(IAggregateTermCommentRpcWebRequest aggregateTermCommentRpcWebRequest) 
    : IQueryHandler<ReadAllPaginatedQuery, ReadAllPaginatedResponse>
{
    [WithValidation]
    public Task<ReadAllPaginatedResponse> HandleAsync(ReadAllPaginatedQuery query, CancellationToken cancellationToken) 
        => aggregateTermCommentRpcWebRequest.ReadAllPaginatedAsync(query, cancellationToken);
}