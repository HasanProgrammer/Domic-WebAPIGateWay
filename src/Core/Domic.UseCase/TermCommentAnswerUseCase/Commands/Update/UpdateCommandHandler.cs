#pragma warning disable CS4014

using Domic.UseCase.TermCommentAnswerUseCase.Contracts.Interfaces;
using Domic.UseCase.TermCommentAnswerUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.TermCommentAnswerUseCase.Commands.Update;

public class UpdateCommandHandler : ICommandHandler<UpdateCommand, UpdateResponse>
{
    private readonly ITermCommentAnswerRpcWebRequest _termCommentAnswerRpcWebRequest;

    public UpdateCommandHandler(ITermCommentAnswerRpcWebRequest termCommentAnswerRpcWebRequest)
        => _termCommentAnswerRpcWebRequest = termCommentAnswerRpcWebRequest;

    public Task BeforeHandleAsync(UpdateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    public Task<UpdateResponse> HandleAsync(UpdateCommand command, CancellationToken cancellationToken)
        => _termCommentAnswerRpcWebRequest.UpdateAsync(command, cancellationToken);

    public Task AfterHandleAsync(UpdateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}