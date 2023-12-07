using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.UserUseCase.DTOs.GRPCs.Active;

namespace Karami.UseCase.UserUseCase.Commands.Active;

public class ActiveCommand : ICommand<ActiveResponse>
{
    public required string UserId { get; init; }
}