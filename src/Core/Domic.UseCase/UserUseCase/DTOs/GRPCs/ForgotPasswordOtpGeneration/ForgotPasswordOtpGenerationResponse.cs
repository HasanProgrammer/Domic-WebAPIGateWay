using Domic.UseCase.Commons.DTOs.GRPCs;

namespace Domic.UseCase.UserUseCase.DTOs.GRPCs.ForgotPasswordOtpGeneration;

public class ForgotPasswordOtpGenerationResponse : BaseResponse
{
    public ForgotPasswordOtpGenerationResponseBody Body { get; set; }
}