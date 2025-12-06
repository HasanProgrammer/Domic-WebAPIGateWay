using Domic.UseCase.TermUseCase.DTOs.GRPCs.ReadAllPaginated;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.TermUseCase.Contracts.Interfaces;

namespace Domic.UseCase.TermUseCase.Queries.ReadAllPaginated;

public class ReadAllPaginatedQueryHandler(ITermRpcWebRequest termRpcWebRequest) 
    : IQueryHandler<ReadAllPaginatedQuery, ReadAllPaginatedResponse>
{
    [WithValidation]
    public Task<ReadAllPaginatedResponse> HandleAsync(ReadAllPaginatedQuery query, CancellationToken cancellationToken) 
        => termRpcWebRequest.ReadAllPaginatedAsync(query, cancellationToken);
}