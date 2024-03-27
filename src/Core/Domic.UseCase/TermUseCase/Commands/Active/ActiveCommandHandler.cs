using Domic.UseCase.TermUseCase.DTOs.GRPCs.Active;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.TermUseCase.Contracts.Interfaces;

namespace Domic.UseCase.TermUseCase.Commands.Active;

public class ActiveCommandHandler(ITermRpcWebRequest termRpcWebRequest) : ICommandHandler<ActiveCommand, ActiveResponse>
{
    public Task<ActiveResponse> HandleAsync(ActiveCommand command, CancellationToken cancellationToken) 
        => termRpcWebRequest.ActiveAsync(command, cancellationToken);
}