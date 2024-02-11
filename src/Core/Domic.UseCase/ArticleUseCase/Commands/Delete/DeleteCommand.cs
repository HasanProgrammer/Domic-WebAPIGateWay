using Domic.UseCase.ArticleUseCase.DTOs.GRPCs.Delete;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.ArticleUseCase.Commands.Delete;

public class DeleteCommand : ICommand<DeleteResponse>
{
    public string TargetId { get; set; }
}