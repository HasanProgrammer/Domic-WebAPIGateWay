using Domic.UseCase.CategoryUseCase.DTOs.GRPCs.Create;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.CategoryUseCase.Commands.Create;

public class CreateCommand : ICommand<CreateResponse>
{
    public string Name { get; set; }
}