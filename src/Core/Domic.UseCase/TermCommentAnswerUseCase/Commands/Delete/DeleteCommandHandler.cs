#pragma warning disable CS4014

using Domic.UseCase.TermCommentAnswerUseCase.Contracts.Interfaces;
using Domic.UseCase.TermCommentAnswerUseCase.DTOs.GRPCs.Delete;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.TermCommentAnswerUseCase.Commands.Delete;

public class DeleteCommandHandler : ICommandHandler<DeleteCommand, DeleteResponse>
{
    private readonly ITermCommentAnswerRpcWebRequest _termCommentAnswerRpcWebRequest;

    public DeleteCommandHandler(ITermCommentAnswerRpcWebRequest termCommentAnswerRpcWebRequest)
        => _termCommentAnswerRpcWebRequest = termCommentAnswerRpcWebRequest;

    public Task BeforeHandleAsync(DeleteCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    public Task<DeleteResponse> HandleAsync(DeleteCommand command, CancellationToken cancellationToken)
        => _termCommentAnswerRpcWebRequest.DeleteAsync(command, cancellationToken);

    public Task AfterHandleAsync(DeleteCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}