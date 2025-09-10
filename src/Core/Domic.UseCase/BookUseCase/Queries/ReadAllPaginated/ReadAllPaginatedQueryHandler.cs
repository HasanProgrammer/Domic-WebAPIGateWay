using Domic.UseCase.BookUseCase.DTOs.GRPCs.ReadAllPaginated;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.BookUseCase.Contracts.Interfaces;

namespace Domic.UseCase.BookUseCase.Queries.ReadAllPaginated;

public class ReadAllPaginatedQueryHandler(IBookRpcWebRequest bookRpcWebRequest) 
    : IQueryHandler<ReadAllPaginatedQuery, ReadAllPaginatedResponse>
{
    [WithValidation]
    public Task<ReadAllPaginatedResponse> HandleAsync(ReadAllPaginatedQuery query, CancellationToken cancellationToken) 
        => bookRpcWebRequest.ReadAllPaginatedAsync(query, cancellationToken);
}