namespace Domic.UseCase.VideoUseCase.DTOs;

public class VideoDto
{
    public string Id { get; set; }
    public string TermId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string VideoUrl { get; set; }
    public int Status { get; set; }
}