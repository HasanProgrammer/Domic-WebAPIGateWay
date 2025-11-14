using Domic.UseCase.CompanyUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.CompanyUseCase.Commands.Update;

public sealed class UpdateCommand : ICommand<UpdateResponse>
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get;set; }
    public required string Field { get; set; }
    public required int? Size { get; set; }
    public required string WebsiteUrl { get; set; }
    public required string ImagePath { get; set; }
}