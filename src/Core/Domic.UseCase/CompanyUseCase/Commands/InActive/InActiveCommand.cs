using Domic.UseCase.CompanyUseCase.DTOs.GRPCs.InActive;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.CompanyUseCase.Commands.InActive;

public sealed class InActiveCommand : ICommand<InActiveResponse>
{
    public required string Id { get; init; }
}