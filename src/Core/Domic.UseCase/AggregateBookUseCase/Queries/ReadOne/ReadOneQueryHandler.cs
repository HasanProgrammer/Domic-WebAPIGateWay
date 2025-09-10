using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.AggregateBookUseCase.Contracts.Interfaces;
using Domic.UseCase.AggregateBookUseCase.DTOs.GRPCs.ReadOne;

namespace Domic.UseCase.AggregateBookUseCase.Queries.ReadOne;

public class ReadOneQueryHandler(IBookRpcWebRequest bookRpcWebRequest) : IQueryHandler<ReadOneQuery, ReadOneResponse>
{
    public Task<ReadOneResponse> HandleAsync(ReadOneQuery query, CancellationToken cancellationToken) 
        => bookRpcWebRequest.ReadOneAsync(query, cancellationToken);
}