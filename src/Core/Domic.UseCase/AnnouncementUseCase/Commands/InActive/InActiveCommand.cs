using Domic.UseCase.AnnouncementUseCase.DTOs.GRPCs.InActive;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.AnnouncementUseCase.Commands.InActive;

public sealed class InActiveCommand : ICommand<InActiveResponse>
{
    public required string Id { get; init; }
}