using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.InActive;

namespace Karami.UseCase.ArticleCommentAnswerUseCase.Commands.InActive;

public class InActiveCommand : ICommand<InActiveResponse>
{
    public required string TargetId { get; set; }
}