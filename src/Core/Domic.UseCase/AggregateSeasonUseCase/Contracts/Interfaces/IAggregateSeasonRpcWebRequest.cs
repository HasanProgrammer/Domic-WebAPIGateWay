using Domic.UseCase.AggregateSeasonUseCase.DTOs.GRPCs.ReadAllPaginated;
using Domic.UseCase.AggregateSeasonUseCase.DTOs.GRPCs.ReadOne;
using Domic.UseCase.AggregateSeasonUseCase.Queries.ReadOne;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.AggregateSeasonUseCase.Queries.ReadAllPaginated;

namespace Domic.UseCase.AggregateSeasonUseCase.Contracts.Interfaces;

public interface IAggregateSeasonRpcWebRequest : IRpcWebRequest
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