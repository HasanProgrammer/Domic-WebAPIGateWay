using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.UserUseCase.DTOs.GRPCs.ReadOne;

namespace Karami.UseCase.UserUseCase.Queries.ReadOne;

public class ReadOneQuery : IQuery<ReadOneResponse>
{
    public string UserId { get; set; }
}