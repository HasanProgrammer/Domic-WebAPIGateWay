using Domic.UseCase.UserUseCase.DTOs.GRPCs.Active;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.UserUseCase.Commands.Active;

public class ActiveCommand : ICommand<ActiveResponse>
{
    public required string Token { get; set; }
    public required string Id { get; init; }
}