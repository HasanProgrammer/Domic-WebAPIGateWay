using Domic.UseCase.AnnouncementUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.AnnouncementUseCase.Contracts.Interfaces;

namespace Domic.UseCase.AnnouncementUseCase.Commands.Update;

public sealed class UpdateCommandHandler(IAnnouncementRpcWebRequest announcementRpcWebRequest) 
    : ICommandHandler<UpdateCommand, UpdateResponse>
{
    public Task BeforeHandleAsync(UpdateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    public Task<UpdateResponse> HandleAsync(UpdateCommand command, CancellationToken cancellationToken) 
        => announcementRpcWebRequest.UpdateAsync(command, cancellationToken);

    public Task AfterHandleAsync(UpdateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}