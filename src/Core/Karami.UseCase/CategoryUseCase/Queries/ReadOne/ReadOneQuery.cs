using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.CategoryUseCase.DTOs.GRPCs.ReadOne;

namespace Karami.UseCase.CategoryUseCase.Queries.ReadOne;

public class ReadOneQuery : IQuery<ReadOneResponse>
{
    public string CategoryId { get; set; }
}