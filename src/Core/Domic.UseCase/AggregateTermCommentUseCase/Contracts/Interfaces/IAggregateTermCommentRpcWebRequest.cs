using Domic.UseCase.AggregateTermCommentUseCase.DTOs.GRPCs.ReadAllPaginated;
using Domic.UseCase.AggregateTermCommentUseCase.DTOs.GRPCs.ReadOne;
using Domic.UseCase.AggregateTermCommentUseCase.Queries.ReadOne;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.AggregateTermCommentUseCase.Queries.ReadAllPaginated;

namespace Domic.UseCase.AggregateTermCommentUseCase.Contracts.Interfaces;

public interface IAggregateTermCommentRpcWebRequest : IRpcWebRequest
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