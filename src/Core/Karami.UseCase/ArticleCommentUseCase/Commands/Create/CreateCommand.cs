using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.ArticleCommentUseCase.DTOs.GRPCs.Create;

namespace Karami.UseCase.ArticleCommentUseCase.Commands.Create;

public class CreateCommand : ICommand<CreateResponse>
{
    public string OwnerId   { get; set; }
    public string ArticleId { get; set; }
    public string Comment   { get; set; }
}