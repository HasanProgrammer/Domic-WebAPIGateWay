using Domic.UseCase.ArticleUseCase.DTOs;

namespace Domic.UseCase.AggregateArticleUseCase.DTOs.GRPCs.ReadOne;

public class ReadOneResponseBody
{
    public AggregateArticleDto Article { get; set; }
}