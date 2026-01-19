using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.UserUseCase.Contracts.Interfaces;
using Domic.UseCase.UserUseCase.DTOs.GRPCs.ForgotPasswordOtpGeneration;

namespace Domic.UseCase.UserUseCase.Commands.ForgotPasswordOtpGeneration;

public class ForgotPasswordOtpGenerationCommandHandler(IUserRpcWebRequest userRpcWebRequest) 
    : ICommandHandler<ForgotPasswordOtpGenerationCommand, ForgotPasswordOtpGenerationResponse>
{
    public Task BeforeHandleAsync(ForgotPasswordOtpGenerationCommand command, CancellationToken cancellationToken)
        => Task.CompletedTask;

    public Task<ForgotPasswordOtpGenerationResponse> HandleAsync(ForgotPasswordOtpGenerationCommand command,
        CancellationToken cancellationToken
    ) => userRpcWebRequest.ForgotPasswordOtpGenerationAsync(command, cancellationToken);

    public Task AfterHandleAsync(ForgotPasswordOtpGenerationCommand command, CancellationToken cancellationToken)
        => Task.CompletedTask;
}