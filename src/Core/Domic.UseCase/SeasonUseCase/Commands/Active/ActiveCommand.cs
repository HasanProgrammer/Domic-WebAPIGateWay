using Domic.UseCase.SeasonUseCase.DTOs.GRPCs.Active;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.SeasonUseCase.Commands.Active;

public class ActiveCommand : ICommand<ActiveResponse>
{
    public required string Id { get; init; }
}