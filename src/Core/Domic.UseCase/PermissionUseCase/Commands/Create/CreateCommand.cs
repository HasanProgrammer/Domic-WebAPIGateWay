using Domic.UseCase.PermissionUseCase.DTOs.GRPCs.Create;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.PermissionUseCase.Commands.Create;

public class CreateCommand : ICommand<CreateResponse>
{
    public string RoleId { get; set; }
    public string Name   { get; set; }
}