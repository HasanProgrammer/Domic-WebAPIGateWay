namespace Domic.UseCase.CampaignUseCase.DTOs;

public class TermDto
{
    public string Id { get; set; }
    public string Name { get; set; }
}

public class CampaignDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal DiscountPercentage { get; set; }
    public List<TermDto> Terms { get; set; }
}