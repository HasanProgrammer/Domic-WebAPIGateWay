using Domic.UseCase.ArticleCommentUseCase.DTOs.GRPCs.Delete;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.ArticleCommentUseCase.Commands.Delete;

public class DeleteCommand : ICommand<DeleteResponse>
{
    public required string TargetId { get; set; }
}