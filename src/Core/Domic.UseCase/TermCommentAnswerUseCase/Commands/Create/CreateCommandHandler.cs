#pragma warning disable CS4014

using Domic.UseCase.TermCommentAnswerUseCase.DTOs.GRPCs.Create;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.TermCommentAnswerUseCase.Contracts.Interfaces;

namespace Domic.UseCase.TermCommentAnswerUseCase.Commands.Create;

public class CreateCommandHandler : ICommandHandler<CreateCommand, CreateResponse>
{
    private readonly ITermCommentAnswerRpcWebRequest _termCommentAnswerRpcWebRequest;

    public CreateCommandHandler(ITermCommentAnswerRpcWebRequest termCommentAnswerRpcWebRequest)
        => _termCommentAnswerRpcWebRequest = termCommentAnswerRpcWebRequest;

    public Task BeforeHandleAsync(CreateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    public Task<CreateResponse> HandleAsync(CreateCommand command, CancellationToken cancellationToken)
        => _termCommentAnswerRpcWebRequest.CreateAsync(command, cancellationToken);

    public Task AfterHandleAsync(CreateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}