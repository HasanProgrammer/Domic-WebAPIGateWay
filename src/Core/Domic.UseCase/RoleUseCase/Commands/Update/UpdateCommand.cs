using Domic.UseCase.RoleUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.RoleUseCase.Commands.Update;

public class UpdateCommand : ICommand<UpdateResponse>
{
    public string Id   { get; set; }
    public string Name { get; set; }
}