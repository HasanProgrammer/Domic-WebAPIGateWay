namespace Domic.UseCase.AggregateSeasonUseCase.DTOs;

public class AggregateSeasonDto
{
    public string Id { get; set; }
    public string TermTitle { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public DateTime EnCreatedAt { get; set; }
    public string FrCreatedAt { get; set; }
}