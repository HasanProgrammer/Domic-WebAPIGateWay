using Domic.UseCase.VideoUseCase.DTOs.GRPCs.ReadAllPaginated;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.VideoUseCase.Contracts.Interfaces;

namespace Domic.UseCase.VideoUseCase.Queries.ReadAllPaginated;

public class ReadAllPaginatedQueryHandler(IVideoRpcWebRequest videoRpcWebRequest) 
    : IQueryHandler<ReadAllPaginatedQuery, ReadAllPaginatedResponse>
{
    [WithValidation]
    public Task<ReadAllPaginatedResponse> HandleAsync(ReadAllPaginatedQuery query, CancellationToken cancellationToken) 
        => videoRpcWebRequest.ReadAllPaginatedAsync(query, cancellationToken);
}