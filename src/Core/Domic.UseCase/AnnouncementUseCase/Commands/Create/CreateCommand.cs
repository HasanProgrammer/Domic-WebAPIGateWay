using Domic.UseCase.AnnouncementUseCase.DTOs.GRPCs.Create;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Commons.Enumerations;

namespace Domic.UseCase.AnnouncementUseCase.Commands.Create;

public sealed class CreateCommand : ICommand<CreateResponse>
{
    public required string Title { get; set; }
    public required string CompanyId { get; set; }
    public required string StackId { get; set; }
    public required int? Budget { get; set; }
    public required Position? Position { get; set; }
    public required List<string> Skills { get; set; }
}