using Karami.UseCase.Commons.DTOs.GRPCs;

namespace Karami.UseCase.UserUseCase.DTOs.GRPCs.Create;

public class CreateResponse : BaseResponse
{
    public CreateResponseBody Body { get; set; }
}