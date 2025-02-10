using Domic.UseCase.TermUseCase.DTOs.GRPCs.InActive;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.TermUseCase.Commands.InActive;

public class InActiveCommand : ICommand<InActiveResponse>
{
    public required string Id { get; init; }
}