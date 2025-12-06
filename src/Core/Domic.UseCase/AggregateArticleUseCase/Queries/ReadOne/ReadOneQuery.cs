using Domic.UseCase.AggregateArticleUseCase.DTOs.GRPCs.ReadOne;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.AggregateArticleUseCase.Queries.ReadOne;

public class ReadOneQuery : IQuery<ReadOneResponse>
{
    public string Id { get; set; }
}