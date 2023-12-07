using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.AggregateArticleUseCase.DTOs.GRPCs.ReadAllPaginated;
using Karami.UseCase.AggregateArticleUseCase.Queries.ReadAllPaginated;

namespace Karami.UseCase.AggregateArticleUseCase.Contracts.Interfaces;

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