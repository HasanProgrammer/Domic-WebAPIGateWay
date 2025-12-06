namespace Domic.UseCase.CampaignUseCase.DTOs;

public class CampaignDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal DiscountPercentage { get; set; }
    public List<string> Terms { get; set; }
}