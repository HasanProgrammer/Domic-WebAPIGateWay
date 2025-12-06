using Domic.UseCase.TermCommentAnswerUseCase.DTOs.GRPCs.Delete;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.TermCommentAnswerUseCase.Commands.Delete;

public class DeleteCommand : ICommand<DeleteResponse>
{
    public required string Id { get; set; }
}