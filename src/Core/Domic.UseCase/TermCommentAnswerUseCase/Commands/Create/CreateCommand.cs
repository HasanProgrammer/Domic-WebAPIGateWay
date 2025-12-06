using Domic.UseCase.TermCommentAnswerUseCase.DTOs.GRPCs.Create;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.TermCommentAnswerUseCase.Commands.Create;

public class CreateCommand : ICommand<CreateResponse>
{
    public string CommentId { get; set; }
    public string Answer    { get; set; }
}