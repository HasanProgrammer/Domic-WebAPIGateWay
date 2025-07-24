using Domic.UseCase.Commons.DTOs.GRPCs;

namespace Domic.UseCase.UserUseCase.DTOs.GRPCs.SignIn;

public class SignInResponse : BaseResponse
{
    public SignInResponseBody Body { get; set; }
}