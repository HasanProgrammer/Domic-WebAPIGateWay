using Domic.UseCase.PermissionUseCase.DTOs.GRPCs.Delete;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.PermissionUseCase.Commands.Delete;

public class DeleteCommand : ICommand<DeleteResponse>
{
    public required string Id { get; set; }
}