using Domic.UseCase.AggregateCampaignUseCase.DTOs.GRPCs.ReadAllPaginated;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.AggregateCampaignUseCase.Contracts.Interfaces;

namespace Domic.UseCase.AggregateCampaignUseCase.Queries.ReadAllPaginated;

public class ReadAllPaginatedQueryHandler(IAggregateCampaignRpcWebRequest aggregateCampaignRpcWebRequest) 
    : IQueryHandler<ReadAllPaginatedQuery, ReadAllPaginatedResponse>
{
    [WithValidation]
    public Task<ReadAllPaginatedResponse> HandleAsync(ReadAllPaginatedQuery query, CancellationToken cancellationToken) 
        => aggregateCampaignRpcWebRequest.ReadAllPaginatedAsync(query, cancellationToken);
}