using Domic.UseCase.StackUseCase.DTOs.GRPCs.Active;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.StackUseCase.Commands.Active;

public sealed class ActiveCommand : ICommand<ActiveResponse>
{
    public required string Id { get; init; }
}