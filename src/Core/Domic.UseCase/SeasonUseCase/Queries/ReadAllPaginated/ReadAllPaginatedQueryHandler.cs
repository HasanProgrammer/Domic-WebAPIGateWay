using Domic.UseCase.SeasonUseCase.DTOs.GRPCs.ReadAllPaginated;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.SeasonUseCase.Contracts.Interfaces;

namespace Domic.UseCase.SeasonUseCase.Queries.ReadAllPaginated;

public class ReadAllPaginatedQueryHandler(ISeasonRpcWebRequest seasonRpcWebRequest) 
    : IQueryHandler<ReadAllPaginatedQuery, ReadAllPaginatedResponse>
{
    [WithValidation]
    public Task<ReadAllPaginatedResponse> HandleAsync(ReadAllPaginatedQuery query, CancellationToken cancellationToken) 
        => seasonRpcWebRequest.ReadAllPaginatedAsync(query, cancellationToken);
}