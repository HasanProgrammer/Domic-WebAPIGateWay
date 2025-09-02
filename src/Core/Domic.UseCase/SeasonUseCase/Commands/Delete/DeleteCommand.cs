using Domic.UseCase.SeasonUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.SeasonUseCase.Commands.Update;

public class DeleteCommand : ICommand<DeleteResponse>
{
    public string Id { get; set; }
}