using Domic.UseCase.Commons.DTOs.GRPCs;

namespace Domic.UseCase.UserUseCase.DTOs.GRPCs.ForgotPasswordOtpVerification;

public class ForgotPasswordOtpVerificationResponse : BaseResponse
{
    public ForgotPasswordOtpVerificationResponseBody Body { get; set; }
}