using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.AggregateBookUseCase.DTOs.GRPCs.ReadOne;

namespace Domic.UseCase.AggregateBookUseCase.Queries.ReadOne;

public class ReadOneQuery : IQuery<ReadOneResponse>
{
    public required string Id { get; set; }
}