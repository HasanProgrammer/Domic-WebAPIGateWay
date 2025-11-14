using Domic.UseCase.StackUseCase.DTOs.GRPCs.Create;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.StackUseCase.Commands.Create;

public sealed class CreateCommand : ICommand<CreateResponse>
{
    public string Name { get; set; }
}