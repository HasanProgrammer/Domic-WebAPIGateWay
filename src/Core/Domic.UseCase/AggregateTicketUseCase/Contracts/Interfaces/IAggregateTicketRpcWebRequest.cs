using Domic.UseCase.AggregateTicketUseCase.DTOs.GRPCs.ReadAllPaginated;
using Domic.UseCase.AggregateTicketUseCase.DTOs.GRPCs.ReadOne;
using Domic.UseCase.AggregateTicketUseCase.Queries.ReadOne;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.AggregateTicketUseCase.Queries.ReadAllPaginated;

namespace Domic.UseCase.AggregateTicketUseCase.Contracts.Interfaces;

public interface IAggregateTicketRpcWebRequest : IRpcWebRequest
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