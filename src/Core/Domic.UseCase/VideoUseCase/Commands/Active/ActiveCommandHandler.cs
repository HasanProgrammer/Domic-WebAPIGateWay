using Domic.UseCase.VideoUseCase.DTOs.GRPCs.Active;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.VideoUseCase.Contracts.Interfaces;

namespace Domic.UseCase.VideoUseCase.Commands.Active;

public class ActiveCommandHandler(IVideoRpcWebRequest videoRpcWebRequest) 
    : ICommandHandler<ActiveCommand, ActiveResponse>
{
    public Task<ActiveResponse> HandleAsync(ActiveCommand command, CancellationToken cancellationToken) 
        => videoRpcWebRequest.ActiveAsync(command, cancellationToken);
}