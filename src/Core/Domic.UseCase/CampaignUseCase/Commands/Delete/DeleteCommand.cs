using Domic.UseCase.CampaignUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.CampaignUseCase.Commands.Update;

public class DeleteCommand : ICommand<DeleteResponse>
{
    public string Id { get; set; }
}