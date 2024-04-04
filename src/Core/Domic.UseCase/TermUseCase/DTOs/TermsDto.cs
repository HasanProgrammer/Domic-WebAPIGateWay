namespace Domic.UseCase.TermUseCase.DTOs;

public class TermsDto
{
    public required string CategoryId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string ImageUrl { get; set; }
    public required long Price { get; set; }
    public required int Status { get; set; }
}