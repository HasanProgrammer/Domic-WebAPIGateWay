using Karami.UseCase.ArticleUseCase.DTOs.ViewModels;

namespace Karami.UseCase.ArticleUseCase.DTOs.GRPCs.ReadOne;

public class ReadOneResponseBody
{
    public ArticlesViewModel Article { get; set; }
}