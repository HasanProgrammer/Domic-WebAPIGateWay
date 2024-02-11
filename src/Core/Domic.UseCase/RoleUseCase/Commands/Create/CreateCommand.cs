using Domic.UseCase.RoleUseCase.DTOs.GRPCs.Create;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.RoleUseCase.Commands.Create;

public class CreateCommand : ICommand<CreateResponse>
{
    public string Name { get; set; }
}