using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.RoleUseCase.DTOs.GRPCs.Create;

namespace Karami.UseCase.RoleUseCase.Commands.Create;

public class CreateCommand : ICommand<CreateResponse>
{
    public string Name { get; set; }
}