using Domic.UseCase.SeasonUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Commons.Enumerations;

namespace Domic.UseCase.SeasonUseCase.Commands.Update;

public class UpdateCommand : ICommand<UpdateResponse>
{
    public required string Id { get; set; }
    public required string TermId { get; set; }
    public required string Name { get; set; }
}