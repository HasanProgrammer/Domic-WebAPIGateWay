using Domic.UseCase.VideoUseCase.Contracts.Interfaces;
using Domic.UseCase.VideoUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.VideoUseCase.Commands.Update;

public class DeleteCommandHandler(IVideoRpcWebRequest videoRpcWebRequest) 
    : ICommandHandler<DeleteCommand, DeleteResponse>
{
    public Task<DeleteResponse> HandleAsync(DeleteCommand command, CancellationToken cancellationToken) 
        => videoRpcWebRequest.DeleteAsync(command, cancellationToken);
}