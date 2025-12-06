using Domic.UseCase.TermCommentAnswerUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.TermCommentAnswerUseCase.Commands.Update;

public class UpdateCommand : ICommand<UpdateResponse>
{
    public string Id     { get; set; }
    public string Answer { get; set; }
}