using Domic.UseCase.Commons.DTOs.GRPCs;

namespace Domic.UseCase.UserUseCase.DTOs.GRPCs.OtpGeneration;

public class OtpGenerationResponse : BaseResponse
{
    public OtpGenerationResponseBody Body { get; set; }
}