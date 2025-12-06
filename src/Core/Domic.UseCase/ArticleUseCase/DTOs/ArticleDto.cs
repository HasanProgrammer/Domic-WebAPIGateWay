namespace Domic.UseCase.ArticleUseCase.DTOs;

public class ArticleDto
{
    public string Id                       { get; set; }
    public string CategoryId               { get; set; }
    public string CreatedBy                { get; set; }
    public string Title                    { get; set; }
    public string Summary                  { get; set; }
    public string Body                     { get; set; }
    public bool IsActive                   { get; set; }
    public DateTime? CreatedAt_EnglishDate { get; set; }
    public string CreatedAt_PersianDate    { get; set; }
    public DateTime? UpdatedAt_EnglishDate { get; set; }
    public string UpdatedAt_PersianDate    { get; set; }
    
    /*---------------------------------------------------------------*/
    
    public IEnumerable<FileDto> Files { get; set; }
}