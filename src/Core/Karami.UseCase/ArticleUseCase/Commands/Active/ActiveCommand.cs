using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.ArticleUseCase.DTOs.GRPCs.Active;

namespace Karami.UseCase.ArticleUseCase.Commands.Active;

public class ActiveCommand : ICommand<ActiveResponse>
{
    public required string TargetId { get; set; }
}