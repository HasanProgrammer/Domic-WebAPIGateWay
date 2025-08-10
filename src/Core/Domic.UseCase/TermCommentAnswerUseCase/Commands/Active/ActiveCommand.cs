using Domic.UseCase.TermCommentAnswerUseCase.DTOs.GRPCs.Active;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.TermCommentAnswerUseCase.Commands.Active;

public class ActiveCommand : ICommand<ActiveResponse>
{
    public required string Id { get; set; }
}