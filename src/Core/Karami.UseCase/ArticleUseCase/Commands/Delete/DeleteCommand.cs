using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.ArticleUseCase.DTOs.GRPCs.Delete;

namespace Karami.UseCase.ArticleUseCase.Commands.Delete;

public class DeleteCommand : ICommand<DeleteResponse>
{
    public string TargetId { get; set; }
}