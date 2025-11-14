using Domic.UseCase.Commons.DTOs.GRPCs;

namespace Domic.UseCase.CompanyUseCase.DTOs.GRPCs.ReadOne;

public class ReadOneResponse : BaseResponse
{
    public ReadOneResponseBody Body { get; set; }
}