using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.UserUseCase.DTOs.GRPCs.OtpGeneration;

namespace Domic.UseCase.UserUseCase.Commands.OtpGeneration;

public class OtpGenerationCommandHandler : ICommandHandler<OtpGenerationCommand, OtpGenerationResponse>
{
    public Task BeforeHandleAsync(OtpGenerationCommand command, CancellationToken cancellationToken)
        => Task.CompletedTask;

    public Task<OtpGenerationResponse> HandleAsync(OtpGenerationCommand command, 
        CancellationToken cancellationToken
    )
    {
        throw new NotImplementedException();
    }

    public Task AfterHandleAsync(OtpGenerationCommand command, CancellationToken cancellationToken)
        => Task.CompletedTask;
}