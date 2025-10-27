using Domic.UseCase.CampaignUseCase.DTOs.GRPCs.InActive;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.CampaignUseCase.Commands.InActive;

public class InActiveCommand : ICommand<InActiveResponse>
{
    public required string Id { get; init; }
}