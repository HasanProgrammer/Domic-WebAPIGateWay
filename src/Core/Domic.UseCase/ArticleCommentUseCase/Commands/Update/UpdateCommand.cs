using Domic.UseCase.ArticleCommentUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.ArticleCommentUseCase.Commands.Update;

public class UpdateCommand : ICommand<UpdateResponse>
{
    public required string TargetId { get; set; }
    public required string Comment  { get; set; }
}