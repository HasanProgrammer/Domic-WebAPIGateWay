using Domic.UseCase.ArticleUseCase.DTOs.ViewModels;

namespace Domic.UseCase.ArticleUseCase.DTOs.GRPCs.ReadOne;

public class ReadOneResponseBody
{
    public ArticleDto Article { get; set; }
}