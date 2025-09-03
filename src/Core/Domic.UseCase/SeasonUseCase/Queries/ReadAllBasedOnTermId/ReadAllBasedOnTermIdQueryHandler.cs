using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.SeasonUseCase.Contracts.Interfaces;
using Domic.UseCase.SeasonUseCase.DTOs.GRPCs.ReadAllBasedOnTermId;

namespace Domic.UseCase.SeasonUseCase.Queries.ReadAllBasedOnTermId;

public class ReadAllBasedOneTermIdQueryHandler(ISeasonRpcWebRequest seasonRpcWebRequest) 
    : IQueryHandler<ReadAllBasedOnTermIdQuery, ReadAllBasedOnTermIdResponse>
{
    [WithValidation]
    public Task<ReadAllBasedOnTermIdResponse> HandleAsync(ReadAllBasedOnTermIdQuery query, CancellationToken cancellationToken) 
        => seasonRpcWebRequest.ReadAllBasedOnTermIdAsync(query, cancellationToken);
}