using Domic.UseCase.CampaignUseCase.DTOs.GRPCs.Active;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.CampaignUseCase.Commands.Active;

public class ActiveCommand : ICommand<ActiveResponse>
{
    public required string Id { get; init; }
}