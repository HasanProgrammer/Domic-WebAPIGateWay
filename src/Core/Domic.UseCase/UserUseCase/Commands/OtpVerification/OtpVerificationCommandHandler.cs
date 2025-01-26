using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.UserUseCase.DTOs.GRPCs.OtpVerification;

namespace Domic.UseCase.UserUseCase.Commands.OtpVerification;

public class OtpVerificationCommandHandler : ICommandHandler<OtpVerificationCommand, OtpVerificationResponse>
{
    public Task BeforeHandleAsync(OtpVerificationCommand command, CancellationToken cancellationToken)
        => Task.CompletedTask;

    public Task<OtpVerificationResponse> HandleAsync(OtpVerificationCommand command, 
        CancellationToken cancellationToken
    )
    {
        throw new NotImplementedException();
    }

    public Task AfterHandleAsync(OtpVerificationCommand command, CancellationToken cancellationToken)
        => Task.CompletedTask;
}