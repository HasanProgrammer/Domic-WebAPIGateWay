#pragma warning disable CS4014

using Domic.UseCase.AnnouncementUseCase.DTOs.GRPCs.Create;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.AnnouncementUseCase.Contracts.Interfaces;

namespace Domic.UseCase.AnnouncementUseCase.Commands.Create;

public sealed class CreateCommandHandler(IAnnouncementRpcWebRequest announcementRpcWebRequest) : ICommandHandler<CreateCommand, CreateResponse>
{
    public Task BeforeHandleAsync(CreateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    public Task<CreateResponse> HandleAsync(CreateCommand command, CancellationToken cancellationToken) 
        => announcementRpcWebRequest.CreateAsync(command, cancellationToken);

    public Task AfterHandleAsync(CreateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}