using Domic.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.InActive;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.ArticleCommentAnswerUseCase.Commands.InActive;

public class InActiveCommand : ICommand<InActiveResponse>
{
    public required string TargetId { get; set; }
}