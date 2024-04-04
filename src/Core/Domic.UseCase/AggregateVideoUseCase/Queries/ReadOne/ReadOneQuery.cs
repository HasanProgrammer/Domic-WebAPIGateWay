using Domic.UseCase.AggregateVideoUseCase.DTOs.GRPCs.ReadOne;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.AggregateVideoUseCase.Queries.ReadOne;

public class ReadOneQuery : IQuery<ReadOneResponse>
{
    public required string TermId { get; set; }
}