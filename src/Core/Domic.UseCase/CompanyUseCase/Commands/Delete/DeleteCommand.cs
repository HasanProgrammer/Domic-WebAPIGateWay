using Domic.UseCase.CompanyUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.CompanyUseCase.Commands.Update;

public sealed class DeleteCommand : ICommand<DeleteResponse>
{
    public string Id { get; set; }
}