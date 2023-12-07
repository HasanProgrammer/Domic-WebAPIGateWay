using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.PermissionUseCase.DTOs.GRPCs.Update;

namespace Karami.UseCase.PermissionUseCase.Commands.Update;

public class UpdateCommand : ICommand<UpdateResponse>
{
    public string PermissionId { get; set; }
    public string RoleId       { get; set; }
    public string Name         { get; set; }
}