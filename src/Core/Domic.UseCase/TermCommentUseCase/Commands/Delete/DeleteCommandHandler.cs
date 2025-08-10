#pragma warning disable CS4014

using Domic.UseCase.TermCommentUseCase.Contracts.Interfaces;
using Domic.UseCase.TermCommentUseCase.DTOs.GRPCs.Delete;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.TermCommentUseCase.Commands.Delete;

public class DeleteCommandHandler : ICommandHandler<DeleteCommand, DeleteResponse>
{
    private readonly ITermCommentRpcWebRequest _termCommentRpcWebRequest;

    public DeleteCommandHandler(ITermCommentRpcWebRequest termCommentRpcWebRequest)
        => _termCommentRpcWebRequest = termCommentRpcWebRequest;

    public Task BeforeHandleAsync(DeleteCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    public Task<DeleteResponse> HandleAsync(DeleteCommand command, CancellationToken cancellationToken)
        => _termCommentRpcWebRequest.DeleteAsync(command, cancellationToken);

    public Task AfterHandleAsync(DeleteCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}