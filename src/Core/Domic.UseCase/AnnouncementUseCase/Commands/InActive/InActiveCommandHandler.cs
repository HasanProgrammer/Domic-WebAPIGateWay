using Domic.UseCase.AnnouncementUseCase.DTOs.GRPCs.InActive;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.AnnouncementUseCase.Contracts.Interfaces;

namespace Domic.UseCase.AnnouncementUseCase.Commands.InActive;

public sealed class InActiveCommandHandler(IAnnouncementRpcWebRequest announcementRpcWebRequest) 
    : ICommandHandler<InActiveCommand, InActiveResponse>
{
    public Task BeforeHandleAsync(InActiveCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    public Task<InActiveResponse> HandleAsync(InActiveCommand command, CancellationToken cancellationToken)
        => announcementRpcWebRequest.InActiveAsync(command, cancellationToken);

    public Task AfterHandleAsync(InActiveCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}