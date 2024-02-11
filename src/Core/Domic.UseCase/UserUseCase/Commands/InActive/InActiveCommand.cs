using Domic.UseCase.UserUseCase.DTOs.GRPCs.InActive;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.UserUseCase.Commands.InActive;

public class InActiveCommand : ICommand<InActiveResponse>
{
    public required string UserId { get; init; }
}