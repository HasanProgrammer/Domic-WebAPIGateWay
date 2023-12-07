using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.RoleUseCase.DTOs.GRPCs.ReadOne;

namespace Karami.UseCase.RoleUseCase.Queries.ReadOne;

public class ReadOneQuery : IQuery<ReadOneResponse>
{
    public string RoleId { get; set; }
}