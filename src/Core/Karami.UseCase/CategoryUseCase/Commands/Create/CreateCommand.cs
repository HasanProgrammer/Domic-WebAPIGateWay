using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.CategoryUseCase.DTOs.GRPCs.Create;

namespace Karami.UseCase.CategoryUseCase.Commands.Create;

public class CreateCommand : ICommand<CreateResponse>
{
    public string Name { get; set; }
}