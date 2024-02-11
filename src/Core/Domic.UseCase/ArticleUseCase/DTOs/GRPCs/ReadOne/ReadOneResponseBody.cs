using Domic.UseCase.ArticleUseCase.DTOs.ViewModels;

namespace Domic.UseCase.ArticleUseCase.DTOs.GRPCs.ReadOne;

public class ReadOneResponseBody
{
    public ArticlesViewModel Article { get; set; }
}