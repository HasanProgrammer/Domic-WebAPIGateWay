using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.Update;

namespace Karami.UseCase.ArticleCommentAnswerUseCase.Commands.Update;

public class UpdateCommand : ICommand<UpdateResponse>
{
    public string TargetId { get; set; }
    public string Answer   { get; set; }
}