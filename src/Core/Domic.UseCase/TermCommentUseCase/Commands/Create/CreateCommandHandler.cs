#pragma warning disable CS4014

using Domic.UseCase.TermCommentUseCase.Contracts.Interfaces;
using Domic.UseCase.TermCommentUseCase.DTOs.GRPCs.Create;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Core.UseCase.Attributes;

namespace Domic.UseCase.TermCommentUseCase.Commands.Create;

public class CreateCommandHandler : ICommandHandler<CreateCommand, CreateResponse>
{
    private readonly ITermCommentRpcWebRequest _termCommentRpcWebRequest;

    public CreateCommandHandler(ITermCommentRpcWebRequest termCommentRpcWebRequest) 
        => _termCommentRpcWebRequest = termCommentRpcWebRequest;

    public Task BeforeHandleAsync(CreateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    [WithValidation]
    public Task<CreateResponse> HandleAsync(CreateCommand command, CancellationToken cancellationToken)
        => _termCommentRpcWebRequest.CreateAsync(command, cancellationToken);

    public Task AfterHandleAsync(CreateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}