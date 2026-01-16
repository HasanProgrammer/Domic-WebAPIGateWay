using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.UserUseCase.Contracts.Interfaces;
using Domic.UseCase.UserUseCase.DTOs.GRPCs.ForgotPasswordOtpVerification;

namespace Domic.UseCase.UserUseCase.Commands.ForgotPasswordOtpVerification;

public class ForgotPasswordOtpVerificationCommandHandler(IUserRpcWebRequest userRpcWebRequest) 
    : ICommandHandler<ForgotPasswordOtpVerificationCommand, ForgotPasswordOtpVerificationResponse>
{
    public Task BeforeHandleAsync(ForgotPasswordOtpVerificationCommand command, CancellationToken cancellationToken)
        => Task.CompletedTask;

    public Task<ForgotPasswordOtpVerificationResponse> HandleAsync(ForgotPasswordOtpVerificationCommand command,
        CancellationToken cancellationToken
    ) => userRpcWebRequest.ForgotPasswordOtpVerificationAsync(command, cancellationToken);

    public Task AfterHandleAsync(ForgotPasswordOtpVerificationCommand command, CancellationToken cancellationToken)
        => Task.CompletedTask;
}