using Domic.UseCase.TermUseCase.DTOs.GRPCs.Active;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.TermUseCase.Commands.Active;

public class ActiveCommand : ICommand<ActiveResponse>
{
    public required string TermId { get; init; }
}