using Domic.UseCase.Commons.DTOs.GRPCs;

namespace Domic.UseCase.FinancialUseCase.DTOs.GRPCs.ChangeStatusTransactionRequest;

public class ChangeStatusTransactionRequestResponse : BaseResponse
{
    public ChangeStatusTransactionRequestResponseBody Body { get; set; }
}