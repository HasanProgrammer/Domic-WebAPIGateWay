using Domic.UseCase.AnnouncementUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.AnnouncementUseCase.Commands.Update;

public sealed class DeleteCommand : ICommand<DeleteResponse>
{
    public string Id { get; set; }
}