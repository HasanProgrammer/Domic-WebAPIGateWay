using Domic.UseCase.CampaignUseCase.DTOs.GRPCs.ReadOne;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.CampaignUseCase.Contracts.Interfaces;

namespace Domic.UseCase.CampaignUseCase.Queries.ReadOne;

public class ReadOneQueryHandler(ICampaignRpcWebRequest campaignRpcWebRequest) : IQueryHandler<ReadOneQuery, ReadOneResponse>
{
    public Task<ReadOneResponse> HandleAsync(ReadOneQuery query, CancellationToken cancellationToken) 
        => campaignRpcWebRequest.ReadOneAsync(query, cancellationToken);
}