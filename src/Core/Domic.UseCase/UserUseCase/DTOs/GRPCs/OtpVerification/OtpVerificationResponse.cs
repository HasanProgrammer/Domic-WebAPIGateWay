using Domic.UseCase.Commons.DTOs.GRPCs;

namespace Domic.UseCase.UserUseCase.DTOs.GRPCs.OtpVerification;

public class OtpVerificationResponse : BaseResponse
{
    public OtpVerificationResponseBody Body { get; set; }
}