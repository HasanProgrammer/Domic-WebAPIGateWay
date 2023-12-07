using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.RoleUseCase.DTOs.GRPCs.Update;

namespace Karami.UseCase.RoleUseCase.Commands.Update;

public class UpdateCommand : ICommand<UpdateResponse>
{
    public string RoleId { get; set; }
    public string Name   { get; set; }
}