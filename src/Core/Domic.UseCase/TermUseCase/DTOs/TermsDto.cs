namespace Domic.UseCase.TermUseCase.DTOs;

public class TermsDto
{
    public required string Id { get; set; }
    public required string CategoryId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string ImageUrl { get; set; }
    public required string Price { get; set; }
    public required int Status { get; set; }
}