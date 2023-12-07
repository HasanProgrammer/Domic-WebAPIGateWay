using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.PermissionUseCase.DTOs.GRPCs.Create;

namespace Karami.UseCase.PermissionUseCase.Commands.Create;

public class CreateCommand : ICommand<CreateResponse>
{
    public string RoleId { get; set; }
    public string Name   { get; set; }
}