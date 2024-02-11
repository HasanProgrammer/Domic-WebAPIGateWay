using Domic.UseCase.ArticleCommentUseCase.DTOs.ViewModels;
using Domic.Core.UseCase.DTOs.ViewModels;

namespace Domic.UseCase.ArticleUseCase.DTOs.ViewModels;

public class AggregateArticlesViewModel : ViewModel
{
    //Article
    
    public required string Id                  { get; set; }
    public required string Title               { get; set; }
    public required string Summary             { get; set; }
    public required string Body                { get; set; }
    public required bool IsDeleted             { get; set; }
    public required bool IsActive              { get; set; }
    public required string CreatedAt_Persian   { get; set; }
    public required string UpdatedAt_Persian   { get; set; }
    public required DateTime CreatedAt_English { get; set; }
    public required DateTime UpdatedAt_English { get; set; }
    
    //User
    
    public required string UserName { get; set; }
    
    //Category
    
    public required string CategoryId   { get; set; }
    public required string CategoryName { get; set; }
    
    //File
    
    public required string IndicatorImage { get; set; }
    
    //Comment
    
    public required List<ArticleCommentsViewModel> Comments { get; set; }
}