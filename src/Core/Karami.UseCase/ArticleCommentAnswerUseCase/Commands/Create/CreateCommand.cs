using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.Create;

namespace Karami.UseCase.ArticleCommentAnswerUseCase.Commands.Create;

public class CreateCommand : ICommand<CreateResponse>
{
    public string OwnerId   { get; set; }
    public string CommentId { get; set; }
    public string Answer    { get; set; }
}