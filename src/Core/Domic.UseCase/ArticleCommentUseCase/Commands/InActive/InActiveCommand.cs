using Domic.UseCase.ArticleCommentUseCase.DTOs.GRPCs.InActive;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.ArticleCommentUseCase.Commands.InActive;

public class InActiveCommand : ICommand<InActiveResponse>
{
    public required string TargetId { get; set; }
}