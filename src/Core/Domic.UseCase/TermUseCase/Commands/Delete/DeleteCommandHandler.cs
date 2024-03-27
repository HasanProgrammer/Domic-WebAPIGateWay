using Domic.UseCase.TermUseCase.Contracts.Interfaces;
using Domic.UseCase.TermUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.TermUseCase.Commands.Update;

public class DeleteCommandHandler(ITermRpcWebRequest termRpcWebRequest) : ICommandHandler<DeleteCommand, DeleteResponse>
{
    public Task<DeleteResponse> HandleAsync(DeleteCommand command, CancellationToken cancellationToken) 
        => termRpcWebRequest.DeleteAsync(command, cancellationToken);
}