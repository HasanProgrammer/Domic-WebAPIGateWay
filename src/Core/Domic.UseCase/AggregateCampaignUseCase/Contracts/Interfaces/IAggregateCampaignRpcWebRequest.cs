using Domic.UseCase.AggregateCampaignUseCase.DTOs.GRPCs.ReadAllPaginated;
using Domic.UseCase.AggregateCampaignUseCase.DTOs.GRPCs.ReadOne;
using Domic.UseCase.AggregateCampaignUseCase.Queries.ReadOne;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.AggregateCampaignUseCase.Queries.ReadAllPaginated;

namespace Domic.UseCase.AggregateCampaignUseCase.Contracts.Interfaces;

public interface IAggregateCampaignRpcWebRequest : IRpcWebRequest
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<ReadOneResponse> ReadOneAsync(ReadOneQuery request, CancellationToken cancellationToken) 
        => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<ReadAllPaginatedResponse> ReadAllPaginatedAsync(ReadAllPaginatedQuery request,
        CancellationToken cancellationToken
    ) => throw new NotImplementedException();
}