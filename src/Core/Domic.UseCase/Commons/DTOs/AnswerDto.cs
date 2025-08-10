namespace Domic.UseCase.Commons.DTOs;

public class AnswerDto
{
    public string Id        { get; set; }
    public string Author    { get; set; }
    public string Answer    { get; set; }
    public string CreatedAt { get; set; }
    public bool IsActive    { get; set; }
}