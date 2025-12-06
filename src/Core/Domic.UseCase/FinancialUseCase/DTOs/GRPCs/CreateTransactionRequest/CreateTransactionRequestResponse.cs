using Domic.UseCase.Commons.DTOs.GRPCs;

namespace Domic.UseCase.FinancialUseCase.DTOs.GRPCs.CreateTransactionRequest;

public class CreateTransactionRequestResponse : BaseResponse
{
    public CreateTransactionRequestResponseBody Body { get; set; }
}