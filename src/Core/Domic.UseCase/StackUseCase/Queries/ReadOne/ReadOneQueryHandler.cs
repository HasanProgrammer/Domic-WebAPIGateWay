using Domic.UseCase.StackUseCase.DTOs.GRPCs.ReadOne;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.StackUseCase.Contracts.Interfaces;

namespace Domic.UseCase.StackUseCase.Queries.ReadOne;

public class ReadOneQueryHandler(IStackRpcWebRequest stackRpcWebRequest) : IQueryHandler<ReadOneQuery, ReadOneResponse>
{
    public Task<ReadOneResponse> HandleAsync(ReadOneQuery query, CancellationToken cancellationToken) 
        => stackRpcWebRequest.ReadOneAsync(query, cancellationToken);
}