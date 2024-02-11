using Domic.UseCase.AggregateArticleUseCase.DTOs.GRPCs.ReadAllPaginated;
using Domic.UseCase.AggregateArticleUseCase.Queries.ReadAllPaginated;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.AggregateArticleUseCase.Contracts.Interfaces;

public interface IAggregateArticleRpcWebRequest : IRpcWebRequest
{
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