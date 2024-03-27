using Domic.UseCase.VideoUseCase.Contracts.Interfaces;
using Domic.UseCase.VideoUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.VideoUseCase.Commands.Update;

public class UpdateCommandHandler(IVideoRpcWebRequest videoRpcWebRequest) 
    : ICommandHandler<UpdateCommand, UpdateResponse>
{
    public Task<UpdateResponse> HandleAsync(UpdateCommand command, CancellationToken cancellationToken) 
        => videoRpcWebRequest.UpdateAsync(command, cancellationToken);
}