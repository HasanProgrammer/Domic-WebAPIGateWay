using Domic.UseCase.CategoryUseCase.DTOs.GRPCs.Delete;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.CategoryUseCase.Commands.Delete;

public class DeleteCommand : ICommand<DeleteResponse>
{
    public string CategoryId { get; set; }
}