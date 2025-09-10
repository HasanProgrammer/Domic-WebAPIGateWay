using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.AggregateBookUseCase.DTOs.GRPCs.ReadAllPaginated;
using Domic.UseCase.AggregateBookUseCase.DTOs.GRPCs.ReadOne;
using Domic.UseCase.AggregateBookUseCase.Queries.ReadAllPaginated;
using Domic.UseCase.AggregateBookUseCase.Queries.ReadOne;

namespace Domic.UseCase.AggregateBookUseCase.Contracts.Interfaces;

public interface IBookRpcWebRequest : IRpcWebRequest
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