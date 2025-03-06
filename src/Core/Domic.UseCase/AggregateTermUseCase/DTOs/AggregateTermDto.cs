namespace Domic.UseCase.AggregateTermUseCase.DTOs;

public class AggregateTermDto
{
    public string TeacherFullName { get; set; }
    public string TeacherImageUrl { get; set; }
    public int CountOfTerm { get; set; }
    public string TermTitle { get; set; }
    public string TermPrice { get; set; }
    public string TermImageUrl { get; set; }
    public string CategoryTitle { get; set; }
}