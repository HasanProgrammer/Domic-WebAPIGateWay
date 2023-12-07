using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.Delete;

namespace Karami.UseCase.ArticleCommentAnswerUseCase.Commands.Delete;

public class DeleteCommand : ICommand<DeleteResponse>
{
    public required string TargetId { get; set; }
}