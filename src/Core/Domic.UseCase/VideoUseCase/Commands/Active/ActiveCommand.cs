using Domic.UseCase.VideoUseCase.DTOs.GRPCs.Active;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.VideoUseCase.Commands.Active;

public class ActiveCommand : ICommand<ActiveResponse>
{
    public required string VideoId { get; init; }
}