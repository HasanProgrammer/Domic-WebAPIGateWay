using Domic.UseCase.VideoUseCase.DTOs.GRPCs.Create;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Commons.Enumerations;

namespace Domic.UseCase.VideoUseCase.Commands.Create;

public class CreateCommand : ICommand<CreateResponse>
{
    public required string SeasonId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string VideoUrl { get; set; }
    public required VideoStatus? Status { get; set; }
    public required int Price { get; set; }
    public required int Duration { get; set; }
}