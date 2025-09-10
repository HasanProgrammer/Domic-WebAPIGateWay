using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.AggregateBookUseCase.Contracts.Interfaces;
using Domic.UseCase.AggregateBookUseCase.DTOs.GRPCs.ReadAllPaginated;

namespace Domic.UseCase.AggregateBookUseCase.Queries.ReadAllPaginated;

public class ReadAllPaginatedQueryHandler(IBookRpcWebRequest bookRpcWebRequest) 
    : IQueryHandler<ReadAllPaginatedQuery, ReadAllPaginatedResponse>
{
    [WithValidation]
    public Task<ReadAllPaginatedResponse> HandleAsync(ReadAllPaginatedQuery query, CancellationToken cancellationToken) 
        => bookRpcWebRequest.ReadAllPaginatedAsync(query, cancellationToken);
}