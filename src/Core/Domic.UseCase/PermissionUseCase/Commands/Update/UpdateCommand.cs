using Domic.UseCase.PermissionUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.PermissionUseCase.Commands.Update;

public class UpdateCommand : ICommand<UpdateResponse>
{
    public string Id     { get; set; }
    public string RoleId { get; set; }
    public string Name   { get; set; }
}