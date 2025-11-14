using Domic.UseCase.CompanyUseCase.DTOs.GRPCs.ReadOne;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.CompanyUseCase.Queries.ReadOne;

public class ReadOneQuery : IQuery<ReadOneResponse>
{
    public required string Id { get; set; }
}