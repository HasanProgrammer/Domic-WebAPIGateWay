using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.Active;

namespace Karami.UseCase.ArticleCommentAnswerUseCase.Commands.Active;

public class ActiveCommand : ICommand<ActiveResponse>
{
    public required string TargetId { get; set; }
}