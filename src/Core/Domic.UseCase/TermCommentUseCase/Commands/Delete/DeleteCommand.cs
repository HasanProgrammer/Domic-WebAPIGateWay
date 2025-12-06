using Domic.UseCase.TermCommentUseCase.DTOs.GRPCs.Delete;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.TermCommentUseCase.Commands.Delete;

public class DeleteCommand : ICommand<DeleteResponse>
{
    public required string Id { get; set; }
}