#pragma warning disable CS4014

using Domic.UseCase.TicketUseCase.Contracts.Interfaces;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.TicketUseCase.Commands.CreateComment;
using Domic.UseCase.TicketUseCase.DTOs.GRPCs.CreateComment;

namespace Domic.UseCase.TicketUseCase.Commands.Create;

public class CreateCommentCommandHandler(ITicketRpcWebRequest ticketRpcWebRequest) 
    : ICommandHandler<CreateCommentCommand, CreateCommentResponse>
{
    public Task BeforeHandleAsync(CreateCommentCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
    
    public Task<CreateCommentResponse> HandleAsync(CreateCommentCommand command, CancellationToken cancellationToken)
        => ticketRpcWebRequest.CreateCommentAsync(command, cancellationToken);

    public Task AfterHandleAsync(CreateCommentCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}