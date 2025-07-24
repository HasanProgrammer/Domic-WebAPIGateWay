using Domic.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.ArticleCommentAnswerUseCase.Commands.Update;

public class UpdateCommand : ICommand<UpdateResponse>
{
    public string TargetId { get; set; }
    public string Answer   { get; set; }
}