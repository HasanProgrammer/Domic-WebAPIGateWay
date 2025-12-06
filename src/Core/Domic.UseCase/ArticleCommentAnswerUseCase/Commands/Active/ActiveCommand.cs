using Domic.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.Active;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.ArticleCommentAnswerUseCase.Commands.Active;

public class ActiveCommand : ICommand<ActiveResponse>
{
    public required string TargetId { get; set; }
}