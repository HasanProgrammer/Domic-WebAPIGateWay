using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.ArticleCommentUseCase.DTOs.GRPCs.Delete;

namespace Karami.UseCase.ArticleCommentUseCase.Commands.Delete;

public class DeleteCommand : ICommand<DeleteResponse>
{
    public required string TargetId { get; set; }
}