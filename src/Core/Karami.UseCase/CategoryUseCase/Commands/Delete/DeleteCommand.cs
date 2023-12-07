using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.CategoryUseCase.DTOs.GRPCs.Delete;

namespace Karami.UseCase.CategoryUseCase.Commands.Delete;

public class DeleteCommand : ICommand<DeleteResponse>
{
    public string CategoryId { get; set; }
}