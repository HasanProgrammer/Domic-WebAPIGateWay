using Domic.UseCase.VideoUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Commons.Enumerations;

namespace Domic.UseCase.VideoUseCase.Commands.Update;

public class UpdateCommand : ICommand<UpdateResponse>
{
    public required string Id { get; set; }
    public required string SeasonId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string VideoUrl { get; set; }
    public required VideoStatus? Status { get; set; }
    public required int Price { get; set; }
    public required int Duration { get; set; }
}