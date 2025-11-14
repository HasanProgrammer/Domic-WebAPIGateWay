using Domic.UseCase.CompanyUseCase.DTOs.GRPCs.Create;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.CompanyUseCase.Commands.Create;

public sealed class CreateCommand : ICommand<CreateResponse>
{
    public required string Name { get; set; }
    public required string Description { get;set; }
    public required string Field { get; set; }
    public required int? Size { get; set; }
    public required string WebsiteUrl { get; set; }
    public required string ImagePath { get; set; }
}