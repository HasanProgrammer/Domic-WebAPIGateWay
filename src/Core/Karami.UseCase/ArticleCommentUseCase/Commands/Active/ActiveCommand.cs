using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.ArticleCommentUseCase.DTOs.GRPCs.Active;

namespace Karami.UseCase.ArticleCommentUseCase.Commands.Active;

public class ActiveCommand : ICommand<ActiveResponse>
{
    public required string TargetId { get; set; }
}