#pragma warning disable CS4014

using Domic.UseCase.TermCommentAnswerUseCase.Contracts.Interfaces;
using Domic.UseCase.TermCommentAnswerUseCase.DTOs.GRPCs.InActive;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.TermCommentAnswerUseCase.Commands.InActive;

public class InActiveCommandHandler : ICommandHandler<InActiveCommand, InActiveResponse>
{
    private readonly ITermCommentAnswerRpcWebRequest _termCommentAnswerRpcWebRequest;

    public InActiveCommandHandler(ITermCommentAnswerRpcWebRequest termCommentAnswerRpcWebRequest)
        => _termCommentAnswerRpcWebRequest = termCommentAnswerRpcWebRequest;

    public Task BeforeHandleAsync(InActiveCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    public Task<InActiveResponse> HandleAsync(InActiveCommand command, CancellationToken cancellationToken)
        => _termCommentAnswerRpcWebRequest.InActiveAsync(command, cancellationToken);

    public Task AfterHandleAsync(InActiveCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}