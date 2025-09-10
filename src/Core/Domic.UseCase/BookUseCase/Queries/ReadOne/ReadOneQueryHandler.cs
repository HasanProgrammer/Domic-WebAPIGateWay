using Domic.UseCase.BookUseCase.DTOs.GRPCs.ReadOne;
using Domic.UseCase.BookUseCase.Contracts.Interfaces;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.BookUseCase.Queries.ReadOne;

public class ReadOneQueryHandler(IBookRpcWebRequest bookRpcWebRequest) : IQueryHandler<ReadOneQuery, ReadOneResponse>
{
    public Task<ReadOneResponse> HandleAsync(ReadOneQuery query, CancellationToken cancellationToken) 
        => bookRpcWebRequest.ReadOneAsync(query, cancellationToken);
}