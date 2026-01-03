#pragma warning disable CS4014

using Domic.UseCase.NotificationUseCase.DTOs.GRPCs.Create;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.NotificationUseCase.Contracts.Interfaces;

namespace Domic.UseCase.NotificationUseCase.Commands.VerifyCode;

public class CreateCommandHandler : ICommandHandler<VerifyCodeCommand, CreateResponse>
{
    private readonly INotificationRpcWebRequest _notificationRpcWebRequest;
    
    public CreateCommandHandler(INotificationRpcWebRequest notificationRpcWebRequest) 
        => _notificationRpcWebRequest = notificationRpcWebRequest;

    public Task BeforeHandleAsync(VerifyCodeCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    public Task<CreateResponse> HandleAsync(VerifyCodeCommand command, CancellationToken cancellationToken)
        => _notificationRpcWebRequest.SendEmailVerifyCodeAsync(command, cancellationToken);

    public Task AfterHandleAsync(VerifyCodeCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}