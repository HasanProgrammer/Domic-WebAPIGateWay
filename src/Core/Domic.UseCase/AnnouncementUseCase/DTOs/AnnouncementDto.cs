namespace Domic.UseCase.AnnouncementUseCase.DTOs;

public sealed class AnnouncementDto
{
    public required string Name { get; set; }
    public required string Description { get;set; }
    public required string Field { get; set; }
    public required int Size { get; set; }
    public required string WebsiteUrl { get; set; }
    public required string ImagePath { get; set; }
}