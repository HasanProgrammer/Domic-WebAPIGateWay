using Domic.UseCase.ArticleCommentUseCase.DTOs.GRPCs.Create;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.ArticleCommentUseCase.Commands.Create;

public class CreateCommand : ICommand<CreateResponse>
{
    public string OwnerId   { get; set; }
    public string ArticleId { get; set; }
    public string Comment   { get; set; }
}