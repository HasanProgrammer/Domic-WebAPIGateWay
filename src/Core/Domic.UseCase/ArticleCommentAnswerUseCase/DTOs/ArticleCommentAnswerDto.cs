namespace Domic.UseCase.ArticleCommentAnswerUseCase.DTOs;

public class ArticleCommentAnswerDto
{
    public string Id            { get; set; }
    public string OwnerFullName { get; set; }
    public string ArticleTitle  { get; set; }
    public string Answer        { get; set; }
    public string CreatedAt     { get; set; }
    public bool IsActive        { get; set; }
}