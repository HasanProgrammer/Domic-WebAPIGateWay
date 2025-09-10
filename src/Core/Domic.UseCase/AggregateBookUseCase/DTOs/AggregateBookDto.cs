namespace Domic.UseCase.AggregateBookUseCase.DTOs;

public class VideoDto
{
    public string Name { get; set; }
    public string Url { get; set; }
}

public class SeasonDto
{
    public string Name { get; set; }
    public List<VideoDto> Videos { get; set; }
}

public class AggregateBookDto
{
    public string Id { get; set; }
    public string TermTitle { get; set; }
    public List<SeasonDto> Seasons { get; set; }
    public DateTime EnBookedAt { get; set; }
    public string FrBookedAt { get; set; }
}