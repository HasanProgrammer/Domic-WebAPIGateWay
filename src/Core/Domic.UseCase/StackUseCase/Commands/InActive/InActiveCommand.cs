using Domic.UseCase.StackUseCase.DTOs.GRPCs.InActive;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.StackUseCase.Commands.InActive;

public sealed class InActiveCommand : ICommand<InActiveResponse>
{
    public required string Id { get; init; }
}