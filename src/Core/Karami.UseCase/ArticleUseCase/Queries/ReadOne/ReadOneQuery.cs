using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.ArticleUseCase.DTOs.GRPCs.ReadOne;

namespace Karami.UseCase.ArticleUseCase.Queries.ReadOne;

public class ReadOneQuery : IQuery<ReadOneResponse>
{
    public string TargetId { get; set; }
}