using Domic.UseCase.AggregateTermCommentUseCase.DTOs.GRPCs.ReadOne;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.AggregateTermCommentUseCase.Queries.ReadOne;

public class ReadOneQuery : IQuery<ReadOneResponse>
{
    public required string Id { get; set; }
}