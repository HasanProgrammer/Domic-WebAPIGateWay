using Domic.UseCase.AnnouncementUseCase.DTOs.GRPCs.Active;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.AnnouncementUseCase.Commands.Active;

public sealed class ActiveCommand : ICommand<ActiveResponse>
{
    public required string Id { get; init; }
}