using Domic.Domain.Commons.Enumerations;
using Domic.UseCase.AggregateSeasonUseCase.DTOs;
using Domic.UseCase.AggregateTermCommentUseCase.DTOs;

namespace Domic.UseCase.AggregateTermUseCase.DTOs;

public class AggregateTermDto
{
    public string Id { get; set; }
    public string TeacherId { get; set; }
    public string TeacherName { get; set; }
    public string TeacherImageUrl { get; set; }
    public string TeacherDescription { get; set; }
    public string CategoryName { get; set; }
    public string Name { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public int Duration { get; set; }
    public string ImageUrl { get; set; }
    public string TiserUrl { get; set; }
    public TermStatus Status { get; set; }
    public bool IsActive { get; set; }
    public string CreateDate { get; set; }
    public string UpdateDate { get; set; }
    public int CountOfStudents { get; set; }
    public List<AggregateSeasonDto> Seasons { get; set; }
    public List<AggregateCommentDto> Comments { get; set; }
}