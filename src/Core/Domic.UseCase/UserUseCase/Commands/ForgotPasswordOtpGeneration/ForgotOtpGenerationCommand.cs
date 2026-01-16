using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.UserUseCase.DTOs.GRPCs.OtpGeneration;

namespace Domic.UseCase.UserUseCase.Commands.ForgotPasswordOtpGeneration;

public class ForgotPasswordOtpGenerationCommand : ICommand<OtpGenerationResponse>
{
    public string EmailAddress { get; set; }
}