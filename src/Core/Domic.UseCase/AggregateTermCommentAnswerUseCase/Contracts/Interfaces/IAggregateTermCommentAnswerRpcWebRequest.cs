using Domic.UseCase.AggregateTermCommentAnswerUseCase.DTOs.GRPCs.ReadAllPaginated;
using Domic.UseCase.AggregateTermCommentAnswerUseCase.DTOs.GRPCs.ReadOne;
using Domic.UseCase.AggregateTermCommentAnswerUseCase.Queries.ReadOne;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.AggregateTermCommentAnswerUseCase.Queries.ReadAllPaginated;

namespace Domic.UseCase.AggregateTermCommentAnswerUseCase.Contracts.Interfaces;

public interface IAggregateTermCommentAnswerRpcWebRequest : IRpcWebRequest
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