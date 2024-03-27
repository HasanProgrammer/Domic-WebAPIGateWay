using Domic.UseCase.TermUseCase.Contracts.Interfaces;
using Domic.UseCase.TermUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.TermUseCase.Commands.Update;

public class UpdateCommandHandler(ITermRpcWebRequest termRpcWebRequest) : ICommandHandler<UpdateCommand, UpdateResponse>
{
    public Task<UpdateResponse> HandleAsync(UpdateCommand command, CancellationToken cancellationToken) 
        => termRpcWebRequest.UpdateAsync(command, cancellationToken);
}