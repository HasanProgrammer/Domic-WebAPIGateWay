using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.PermissionUseCase.DTOs.GRPCs.Delete;

namespace Karami.UseCase.PermissionUseCase.Commands.Delete;

public class DeleteCommand : ICommand<DeleteResponse>
{
    public string PermissionId { get; set; }
}