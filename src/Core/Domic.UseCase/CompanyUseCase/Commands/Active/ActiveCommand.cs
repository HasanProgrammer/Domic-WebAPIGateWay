using Domic.UseCase.CompanyUseCase.DTOs.GRPCs.Active;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.CompanyUseCase.Commands.Active;

public sealed class ActiveCommand : ICommand<ActiveResponse>
{
    public required string Id { get; init; }
}