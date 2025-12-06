#pragma warning disable CS4014

using Domic.UseCase.TermCommentUseCase.Contracts.Interfaces;
using Domic.UseCase.TermCommentUseCase.DTOs.GRPCs.InActive;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.TermCommentUseCase.Commands.InActive;

public class InActiveCommandHandler : ICommandHandler<InActiveCommand, InActiveResponse>
{
    private readonly ITermCommentRpcWebRequest _termCommentRpcWebRequest;

    public InActiveCommandHandler(ITermCommentRpcWebRequest termCommentRpcWebRequest)
        => _termCommentRpcWebRequest = termCommentRpcWebRequest;

    public Task BeforeHandleAsync(InActiveCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    public Task<InActiveResponse> HandleAsync(InActiveCommand command, CancellationToken cancellationToken)
        => _termCommentRpcWebRequest.InActiveAsync(command, cancellationToken);

    public Task AfterHandleAsync(InActiveCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}