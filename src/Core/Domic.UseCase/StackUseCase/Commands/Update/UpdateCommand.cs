using Domic.UseCase.StackUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.StackUseCase.Commands.Update;

public sealed class UpdateCommand : ICommand<UpdateResponse>
{
    public required string Id { get; set; }
    public required string TermId { get; set; }
    public required string Name { get; set; }
}