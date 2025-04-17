using Domic.UseCase.ArticleCommentAnswerUseCase.DTOs;

namespace Domic.UseCase.ArticleCommentUseCase.DTOs;

public class ArticleCommentDto
{
    public string Id            { get; set; }
    public string OwnerFullName { get; set; }
    public string ArticleTitle  { get; set; }
    public string Comment       { get; set; }
    public string CreatedAt     { get; set; }
    public bool IsActive        { get; set; }
    
    public List<ArticleCommentAnswerDto> Answers { get; set; }
}