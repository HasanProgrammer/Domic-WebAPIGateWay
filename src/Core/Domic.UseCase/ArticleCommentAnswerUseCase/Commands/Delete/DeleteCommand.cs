using Domic.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.Delete;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.ArticleCommentAnswerUseCase.Commands.Delete;

public class DeleteCommand : ICommand<DeleteResponse>
{
    public required string TargetId { get; set; }
}