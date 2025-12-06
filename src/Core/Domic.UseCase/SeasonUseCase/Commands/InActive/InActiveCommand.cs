using Domic.UseCase.SeasonUseCase.DTOs.GRPCs.InActive;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.SeasonUseCase.Commands.InActive;

public class InActiveCommand : ICommand<InActiveResponse>
{
    public required string Id { get; init; }
}