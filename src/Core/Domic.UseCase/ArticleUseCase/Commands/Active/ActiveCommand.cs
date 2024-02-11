using Domic.UseCase.ArticleUseCase.DTOs.GRPCs.Active;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.ArticleUseCase.Commands.Active;

public class ActiveCommand : ICommand<ActiveResponse>
{
    public required string TargetId { get; set; }
}