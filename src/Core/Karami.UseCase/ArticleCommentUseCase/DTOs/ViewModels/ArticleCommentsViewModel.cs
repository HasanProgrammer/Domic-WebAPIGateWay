using Karami.Core.UseCase.DTOs.ViewModels;
using Karami.UseCase.ArticleCommentAnswerUseCase.DTOs.ViewModels;

namespace Karami.UseCase.ArticleCommentUseCase.DTOs.ViewModels;

public class ArticleCommentsViewModel : ViewModel
{
    public string Id            { get; set; }
    public string OwnerFullName { get; set; }
    public string ArticleTitle  { get; set; }
    public string Comment       { get; set; }
    public string CreatedAt     { get; set; }
    public bool IsActive        { get; set; }
    
    public List<ArticleCommentAnswersViewModel> Answers { get; set; }
}