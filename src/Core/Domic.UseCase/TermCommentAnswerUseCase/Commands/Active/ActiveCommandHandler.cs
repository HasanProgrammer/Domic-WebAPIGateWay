#pragma warning disable CS4014

using Domic.UseCase.TermCommentAnswerUseCase.DTOs.GRPCs.Active;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.TermCommentAnswerUseCase.Contracts.Interfaces;

namespace Domic.UseCase.TermCommentAnswerUseCase.Commands.Active;

public class ActiveCommandHandler : ICommandHandler<ActiveCommand, ActiveResponse>
{
    private readonly ITermCommentAnswerRpcWebRequest _termCommentAnswerRpcWebRequest;

    public Task BeforeHandleAsync(ActiveCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    public ActiveCommandHandler(ITermCommentAnswerRpcWebRequest termCommentAnswerRpcWebRequest)
        => _termCommentAnswerRpcWebRequest = termCommentAnswerRpcWebRequest;
    
    public Task<ActiveResponse> HandleAsync(ActiveCommand command, CancellationToken cancellationToken)
        => _termCommentAnswerRpcWebRequest.ActiveAsync(command, cancellationToken);

    public Task AfterHandleAsync(ActiveCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}