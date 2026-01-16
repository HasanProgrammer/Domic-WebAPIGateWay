using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.UserUseCase.DTOs.GRPCs.ForgotPasswordOtpVerification;

namespace Domic.UseCase.UserUseCase.Commands.ForgotPasswordOtpVerification;

public class ForgotPasswordOtpVerificationCommand : ICommand<ForgotPasswordOtpVerificationResponse>
{
    public string EmailAddress { get; set; }
    public string EmailCode { get; set; }
    public string NewPassword { get; set; }
}