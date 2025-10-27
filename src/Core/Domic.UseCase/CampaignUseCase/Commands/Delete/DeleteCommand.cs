using Domic.UseCase.CampaignUseCase.DTOs.GRPCs.Delete;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.CampaignUseCase.Commands.Delete;

public class DeleteCommand : ICommand<DeleteResponse>
{
    public string Id { get; set; }
}