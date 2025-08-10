#pragma warning disable CS4014

using Domic.UseCase.TermCommentUseCase.Contracts.Interfaces;
using Domic.UseCase.TermCommentUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.TermCommentUseCase.Commands.Update;

public class UpdateCommandHandler : ICommandHandler<UpdateCommand, UpdateResponse>
{
    private readonly ITermCommentRpcWebRequest _termCommentRpcWebRequest;

    public UpdateCommandHandler(ITermCommentRpcWebRequest termCommentRpcWebRequest)
        => _termCommentRpcWebRequest = termCommentRpcWebRequest;

    public Task BeforeHandleAsync(UpdateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    public Task<UpdateResponse> HandleAsync(UpdateCommand command, CancellationToken cancellationToken)
        => _termCommentRpcWebRequest.UpdateAsync(command, cancellationToken);

    public Task AfterHandleAsync(UpdateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}