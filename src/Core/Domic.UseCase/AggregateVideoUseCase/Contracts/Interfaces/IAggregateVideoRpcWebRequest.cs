using Domic.UseCase.AggregateVideoUseCase.DTOs.GRPCs.ReadAllPaginated;
using Domic.UseCase.AggregateVideoUseCase.DTOs.GRPCs.ReadOne;
using Domic.UseCase.AggregateVideoUseCase.Queries.ReadOne;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.AggregateVideoUseCase.Queries.ReadAllPaginated;

namespace Domic.UseCase.AggregateVideoUseCase.Contracts.Interfaces;

public interface IAggregateVideoRpcWebRequest : IRpcWebRequest
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