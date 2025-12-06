using Domic.UseCase.StackUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.StackUseCase.Commands.Update;

public sealed class DeleteCommand : ICommand<DeleteResponse>
{
    public string Id { get; set; }
}