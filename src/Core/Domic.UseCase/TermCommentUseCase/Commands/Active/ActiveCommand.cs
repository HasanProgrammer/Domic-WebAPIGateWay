using Domic.UseCase.TermCommentUseCase.DTOs.GRPCs.Active;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.TermCommentUseCase.Commands.Active;

public class ActiveCommand : ICommand<ActiveResponse>
{
    public required string Id { get; set; }
}