using Domic.UseCase.VideoUseCase.Contracts.Interfaces;
using Domic.UseCase.VideoUseCase.DTOs.GRPCs.InActive;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.VideoUseCase.Commands.InActive;

public class InActiveCommandHandler(IVideoRpcWebRequest videoRpcWebRequest) 
    : ICommandHandler<InActiveCommand, InActiveResponse>
{
    public Task<InActiveResponse> HandleAsync(InActiveCommand command, CancellationToken cancellationToken)
        => videoRpcWebRequest.InActiveAsync(command, cancellationToken);
}