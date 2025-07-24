using Domic.UseCase.CategoryUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.CategoryUseCase.Commands.Update;

public class UpdateCommand : ICommand<UpdateResponse>
{
    public string Id   { get; set; }
    public string Name { get; set; }
}