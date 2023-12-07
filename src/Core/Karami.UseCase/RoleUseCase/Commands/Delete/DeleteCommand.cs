using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.RoleUseCase.DTOs.GRPCs.Delete;

namespace Karami.UseCase.RoleUseCase.Commands.SoftDelete;

public class DeleteCommand : ICommand<DeleteResponse>
{
    public string RoleId { get; set; }
}