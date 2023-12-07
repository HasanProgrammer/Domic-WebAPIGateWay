using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.ArticleUseCase.DTOs.GRPCs.InActive;

namespace Karami.UseCase.ArticleUseCase.Commands.InActive;

public class InActiveCommand : ICommand<InActiveResponse>
{
    public required string TargetId { get; set; }
}