using Domic.UseCase.ArticleUseCase.DTOs.GRPCs.InActive;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.ArticleUseCase.Commands.InActive;

public class InActiveCommand : ICommand<InActiveResponse>
{
    public required string TargetId { get; set; }
}