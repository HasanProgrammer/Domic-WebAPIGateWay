namespace Domic.UseCase.AggregateTermCommentAnswerUseCase.DTOs;

public class AggregateCommentAnswerDto
{
    public string Id { get; set; }
    public string CommentId { get; set; }
    public string TermTitle { get; set; }
    public string Author { get; set; }
    public string AuthorImageUrl { get; set; }
    public string Answer { get; set; }
    public bool IsActive { get; set; }
    public DateTime EnCreatedAt { get; set; }
    public string FrCreatedAt { get; set; }
}