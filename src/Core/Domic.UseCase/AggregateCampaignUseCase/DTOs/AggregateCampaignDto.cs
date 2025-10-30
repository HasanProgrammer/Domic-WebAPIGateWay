namespace Domic.UseCase.AggregateCampaignUseCase.DTOs;

public class AggregateCampaignDto
{
    public string Id { get; set; }
    public string AuthorId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime EnStartDate { get; set; }
    public DateTime EnEndDate { get; set; }
    public string FrStartDate { get; set; }
    public string FrEndDate { get; set; }
    public DateTime EnCreatedAt { get; set; }
    public DateTime EnUpdatedAt { get; set; }
    public string FrCreatedAt { get; set; }
    public string FrUpdatedAt { get; set; }
    public decimal DiscountPercentage { get; set; }
    public bool IsActive { get; set; }
}