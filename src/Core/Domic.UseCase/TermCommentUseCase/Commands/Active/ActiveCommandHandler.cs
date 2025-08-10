#pragma warning disable CS4014

using Domic.UseCase.TermCommentUseCase.Contracts.Interfaces;
using Domic.UseCase.TermCommentUseCase.DTOs.GRPCs.Active;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.TermCommentUseCase.Commands.Active;

public class ActiveCommandHandler : ICommandHandler<ActiveCommand, ActiveResponse>
{
    private readonly ITermCommentRpcWebRequest _TermCommentRpcWebRequest;

    public ActiveCommandHandler(ITermCommentRpcWebRequest TermCommentRpcWebRequest)
        => _TermCommentRpcWebRequest = TermCommentRpcWebRequest;

    public Task BeforeHandleAsync(ActiveCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    public Task<ActiveResponse> HandleAsync(ActiveCommand command, CancellationToken cancellationToken)
        => _TermCommentRpcWebRequest.ActiveAsync(command, cancellationToken);

    public Task AfterHandleAsync(ActiveCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}