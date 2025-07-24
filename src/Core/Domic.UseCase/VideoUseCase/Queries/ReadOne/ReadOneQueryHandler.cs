using Domic.UseCase.VideoUseCase.DTOs.GRPCs.ReadOne;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.VideoUseCase.Contracts.Interfaces;

namespace Domic.UseCase.VideoUseCase.Queries.ReadOne;

public class ReadOneQueryHandler(IVideoRpcWebRequest videoRpcWebRequest) : IQueryHandler<ReadOneQuery, ReadOneResponse>
{
    public Task<ReadOneResponse> HandleAsync(ReadOneQuery query, CancellationToken cancellationToken) 
        => videoRpcWebRequest.ReadOneAsync(query, cancellationToken);
}