using Domic.Domain.Commons.Enumerations;

namespace Domic.UseCase.AggregateVideoUseCase.DTOs;

public class AggregateVideosDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Term { get; set; }
    public string Teacher { get; set; }
    public string VideoUrl { get; set; }
    public string Type { get; set; }
    public int Price { get; set; }
    public int Duration { get; set; }
    public VideoStatus TypeValue { get; set; }
    public bool IsActive { get; set; }
    public DateTime EnCreatedAt { get; set; }
    public string CreateDate { get; set; }
    public string UpdateDate { get; set; }
}