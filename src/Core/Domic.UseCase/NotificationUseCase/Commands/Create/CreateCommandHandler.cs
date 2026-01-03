#pragma warning disable CS4014

using Domic.UseCase.NotificationUseCase.DTOs.GRPCs.Create;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.NotificationUseCase.Contracts.Interfaces;

namespace Domic.UseCase.NotificationUseCase.Commands.Create;

public class CreateCommandHandler : ICommandHandler<CreateCommand, CreateResponse>
{
    private readonly INotificationRpcWebRequest _notificationRpcWebRequest;
    
    public CreateCommandHandler(INotificationRpcWebRequest notificationRpcWebRequest) 
        => _notificationRpcWebRequest = notificationRpcWebRequest;

    public Task BeforeHandleAsync(CreateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    public Task<CreateResponse> HandleAsync(CreateCommand command, CancellationToken cancellationToken)
        => _notificationRpcWebRequest.SendEmailVerifyCodeAsync(command, cancellationToken);

    public Task AfterHandleAsync(CreateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}