using Karami.UseCase.Commons.DTOs.GRPCs;

namespace Karami.UseCase.UserUseCase.DTOs.GRPCs.SignIn;

public class SignInResponse : BaseResponse
{
    public SignInResponseBody Body { get; set; }
}