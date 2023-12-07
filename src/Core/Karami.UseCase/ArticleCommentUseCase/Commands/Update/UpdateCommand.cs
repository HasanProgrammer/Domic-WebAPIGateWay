using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.ArticleCommentUseCase.DTOs.GRPCs.Update;

namespace Karami.UseCase.ArticleCommentUseCase.Commands.Update;

public class UpdateCommand : ICommand<UpdateResponse>
{
    public required string TargetId { get; set; }
    public required string Comment  { get; set; }
}