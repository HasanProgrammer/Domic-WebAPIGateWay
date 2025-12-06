using Domic.UseCase.CampaignUseCase.DTOs.GRPCs.Create;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.CampaignUseCase.Commands.Create;

public class CreateCommand : ICommand<CreateResponse>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public long DiscountPercentage { get; set; }
    public List<string> Terms { get; set; }
}