using Domic.UseCase.SkillUseCase.DTOs.GRPCs.ReadOne;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.SkillUseCase.Contracts.Interfaces;

namespace Domic.UseCase.SkillUseCase.Queries.ReadOne;

public class ReadOneQueryHandler(ISkillRpcWebRequest skillRpcWebRequest) : IQueryHandler<ReadOneQuery, ReadOneResponse>
{
    public Task<ReadOneResponse> HandleAsync(ReadOneQuery query, CancellationToken cancellationToken) 
        => skillRpcWebRequest.ReadOneAsync(query, cancellationToken);
}