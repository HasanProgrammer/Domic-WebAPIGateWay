using Domic.Domain.Commons.Enumerations;

namespace Domic.UseCase.AggregateTermUseCase.DTOs;

public class AggregateTermDto
{
    public string Id { get; set; }
    public string TeacherId { get; set; }
    public string TeacherName { get; set; }
    public string TeacherImageUrl { get; set; }
    public string CategoryName { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public long Price { get; set; }
    public string ImageUrl { get; set; }
    public TermStatus Status { get; set; }
    public string CreateDate { get; set; }
    public string UpdateDate { get; set; }
}