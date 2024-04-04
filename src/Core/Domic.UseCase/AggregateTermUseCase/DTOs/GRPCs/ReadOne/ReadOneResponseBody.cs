using Domic.UseCase.AggregateTermUseCase.DTOs;

namespace Domic.UseCase.AggregateTermUseCase.DTOs.GRPCs.ReadOne;

public class ReadOneResponseBody
{
    public AggregateTermsDto Terms { get; set; }
}