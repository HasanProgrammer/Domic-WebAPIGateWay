using Domic.Domain.Commons.Enumerations;

namespace Domic.UseCase.AggregateTermUseCase.DTOs;

public class LandingAggregateTermDto
{
    public string Id { get; set; }
    public string TeacherName { get; set; }
    public string TeacherImageUrl { get; set; }
    public string TeacherDescription { get; set; }
    public string Name { get; set; }
    public string Summary { get; set; }
    public int Price { get; set; }
    public string ImageUrl { get; set; }
    public string TiserUrl { get; set; }
    public TermStatus Status { get; set; }
}