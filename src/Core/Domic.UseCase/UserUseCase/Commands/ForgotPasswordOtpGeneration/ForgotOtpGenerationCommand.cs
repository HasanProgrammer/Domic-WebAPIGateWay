using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.UserUseCase.DTOs.GRPCs.ForgotPasswordOtpGeneration;

namespace Domic.UseCase.UserUseCase.Commands.ForgotPasswordOtpGeneration;

public class ForgotPasswordOtpGenerationCommand : ICommand<ForgotPasswordOtpGenerationResponse>
{
    public string EmailAddress { get; set; }
}