using Domic.UseCase.AggregateVideoUseCase.DTOs;

namespace Domic.UseCase.AggregateSeasonUseCase.DTOs;

public class AggregateSeasonDto
{
    public string Id { get; set; }
    public string AuthorId { get; set; }
    public string TermId { get; set; }
    public string TermTitle { get; set; }
    public string Name { get; set; }
    public DateTime EnCreatedAt { get; set; }
    public string CreateDate { get; set; }
    public string UpdateDate { get; set; }
    public bool IsActive { get; set; }
    public List<AggregateVideosDto> Videos { get; set; }
}