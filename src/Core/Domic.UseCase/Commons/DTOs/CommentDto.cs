namespace Domic.UseCase.Commons.DTOs;

public class CommentDto
{
    public string Id        { get; set; }
    public string Author    { get; set; }
    public string Comment   { get; set; }
    public string CreatedAt { get; set; }
    public bool IsActive    { get; set; }
    
    public List<AnswerDto> Answers { get; set; }
}