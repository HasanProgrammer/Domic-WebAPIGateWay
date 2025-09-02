using Domic.UseCase.SeasonUseCase.DTOs.GRPCs.Create;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.SeasonUseCase.Commands.Create;

public class CreateCommand : ICommand<CreateResponse>
{
    public required string TermId { get; set; }
    public required string Name { get; set; }
}