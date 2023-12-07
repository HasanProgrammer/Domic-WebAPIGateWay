using Karami.Core.UseCase.DTOs.ViewModels;

namespace Karami.UseCase.ArticleCommentAnswerUseCase.DTOs.ViewModels;

public class ArticleCommentAnswersViewModel : ViewModel
{
    public string Id            { get; set; }
    public string OwnerFullName { get; set; }
    public string ArticleTitle  { get; set; }
    public string Answer        { get; set; }
    public string CreatedAt     { get; set; }
    public bool IsActive        { get; set; }
}