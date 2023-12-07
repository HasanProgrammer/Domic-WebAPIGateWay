using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.PermissionUseCase.DTOs.GRPCs.ReadOne;

namespace Karami.UseCase.PermissionUseCase.Queries.ReadOne;

public class ReadOneQuery : IQuery<ReadOneResponse>
{
    public string PermissionId { get; set; }
}