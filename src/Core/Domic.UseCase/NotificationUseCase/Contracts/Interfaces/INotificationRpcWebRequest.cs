using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.NotificationUseCase.Commands.VerifyCode;
using Domic.UseCase.NotificationUseCase.DTOs.GRPCs.Create;

namespace Domic.UseCase.NotificationUseCase.Contracts.Interfaces;

public interface INotificationRpcWebRequest : IRpcWebRequest
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<CreateResponse> SendEmailVerifyCodeAsync(VerifyCodeCommand request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}