using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.CategoryUseCase.DTOs.GRPCs.Update;

namespace Karami.UseCase.CategoryUseCase.Commands.Update;

public class UpdateCommand : ICommand<UpdateResponse>
{
    public string Id   { get; set; }
    public string Name { get; set; }
}