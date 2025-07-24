using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.UserUseCase.DTOs.GRPCs.OtpVerification;

namespace Domic.UseCase.UserUseCase.Commands.OtpVerification;

public class OtpVerificationCommand : ICommand<OtpVerificationResponse>
{
    public string Code { get; set; }
    public string PhoneNumber { get; set; }
}