using Domic.UseCase.SeasonUseCase.DTOs.GRPCs.ReadOne;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.SeasonUseCase.Contracts.Interfaces;

namespace Domic.UseCase.SeasonUseCase.Queries.ReadOne;

public class ReadOneQueryHandler(ISeasonRpcWebRequest seasonRpcWebRequest) : IQueryHandler<ReadOneQuery, ReadOneResponse>
{
    public Task<ReadOneResponse> HandleAsync(ReadOneQuery query, CancellationToken cancellationToken) 
        => seasonRpcWebRequest.ReadOneAsync(query, cancellationToken);
}