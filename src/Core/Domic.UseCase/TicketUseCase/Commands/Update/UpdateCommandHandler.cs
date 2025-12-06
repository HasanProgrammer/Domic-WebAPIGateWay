using Domic.Core.UseCase.Attributes;
using Domic.UseCase.TicketUseCase.Contracts.Interfaces;
using Domic.UseCase.TicketUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.TicketUseCase.Commands.Update;

public class UpdateCommandHandler(ITicketRpcWebRequest TicketRpcWebRequest) 
    : ICommandHandler<UpdateCommand, UpdateResponse>
{
    public Task BeforeHandleAsync(UpdateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    [WithValidation]
    public Task<UpdateResponse> HandleAsync(UpdateCommand command, CancellationToken cancellationToken) 
        => TicketRpcWebRequest.UpdateAsync(command, cancellationToken);

    public Task AfterHandleAsync(UpdateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}