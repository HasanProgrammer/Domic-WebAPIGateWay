using Domic.Core.UseCase.Contracts.Abstracts;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.SeasonUseCase.DTOs.GRPCs.ReadAllBasedOnTermId;

namespace Domic.UseCase.SeasonUseCase.Queries.ReadAllBasedOnTermId;

public class ReadAllBasedOnTermIdQuery : IQuery<ReadAllBasedOnTermIdResponse>
{
    public string TermId { get; set; }
}