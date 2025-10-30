using Domic.UseCase.AggregateCampaignUseCase.DTOs.GRPCs.ReadOne;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.AggregateCampaignUseCase.Contracts.Interfaces;

namespace Domic.UseCase.AggregateCampaignUseCase.Queries.ReadOne;

public class ReadOneQueryHandler(IAggregateCampaignRpcWebRequest aggregateCampaignRpcWebRequest) 
    : IQueryHandler<ReadOneQuery, ReadOneResponse>
{
    public Task<ReadOneResponse> HandleAsync(ReadOneQuery query, CancellationToken cancellationToken) 
        => aggregateCampaignRpcWebRequest.ReadOneAsync(query, cancellationToken);
}