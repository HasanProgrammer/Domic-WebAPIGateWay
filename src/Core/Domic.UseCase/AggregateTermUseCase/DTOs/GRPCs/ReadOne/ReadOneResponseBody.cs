using Domic.UseCase.AggregateTermUseCase.DTOs;

namespace Domic.UseCase.AggregateTermUseCase.DTOs.GRPCs.ReadOne;

public class ReadOneResponseBody
{
    public AggregateTermDto Term { get; set; }
}