using Domic.UseCase.AnnouncementUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.AnnouncementUseCase.Contracts.Interfaces;

namespace Domic.UseCase.AnnouncementUseCase.Commands.Update;

public sealed class DeleteCommandHandler(IAnnouncementRpcWebRequest announcementRpcWebRequest) : ICommandHandler<DeleteCommand, DeleteResponse>
{
    public Task BeforeHandleAsync(DeleteCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    public Task<DeleteResponse> HandleAsync(DeleteCommand command, CancellationToken cancellationToken) 
        => announcementRpcWebRequest.DeleteAsync(command, cancellationToken);

    public Task AfterHandleAsync(DeleteCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}