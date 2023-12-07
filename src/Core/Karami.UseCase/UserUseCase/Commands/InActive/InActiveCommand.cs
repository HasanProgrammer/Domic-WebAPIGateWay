using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.UserUseCase.DTOs.GRPCs.InActive;

namespace Karami.UseCase.UserUseCase.Commands.InActive;

public class InActiveCommand : ICommand<InActiveResponse>
{
    public required string UserId { get; init; }
}