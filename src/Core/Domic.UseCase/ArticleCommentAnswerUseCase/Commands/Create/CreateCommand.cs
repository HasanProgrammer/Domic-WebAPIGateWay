using Domic.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.Create;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.ArticleCommentAnswerUseCase.Commands.Create;

public class CreateCommand : ICommand<CreateResponse>
{
    public string OwnerId   { get; set; }
    public string CommentId { get; set; }
    public string Answer    { get; set; }
}