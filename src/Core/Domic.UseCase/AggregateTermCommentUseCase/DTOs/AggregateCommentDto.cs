
using Domic.UseCase.AggregateTermCommentAnswerUseCase.DTOs;

namespace Domic.UseCase.AggregateTermCommentUseCase.DTOs;

public class AggregateCommentDto
{
    public string Id { get; set; }
    public string TermTitle { get; set; }
    public string Author { get; set; }
    public string AuthorImageUrl { get; set; }
    public string Comment { get; set; }
    public bool IsActive { get; set; }
    public DateTime EnCreatedAt { get; set; }
    public string FrCreatedAt { get; set; }
    public List<AggregateCommentAnswerDto> Answers { get; set; }
}