using Domic.UseCase.AnnouncementUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Commons.Enumerations;

namespace Domic.UseCase.AnnouncementUseCase.Commands.Update;

public sealed class UpdateCommand : ICommand<UpdateResponse>
{
    public required string Id { get; set; }
    public required string Title { get; set; }
    public required string CompanyId { get; set; }
    public required string StackId { get; set; }
    public required int? Budget { get; set; }
    public required Position? Position { get; set; }
    public required List<string> Skills { get; set; }
}