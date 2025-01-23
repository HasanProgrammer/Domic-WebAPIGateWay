using Domic.UseCase.RoleUseCase.DTOs.GRPCs.Delete;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.RoleUseCase.Commands.SoftDelete;

public class DeleteCommand : ICommand<DeleteResponse>
{
    public string Id { get; set; }
}