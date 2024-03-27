#pragma warning disable CS4014

using Domic.UseCase.VideoUseCase.Contracts.Interfaces;
using Domic.UseCase.VideoUseCase.DTOs.GRPCs.Create;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.VideoUseCase.Commands.Create;

public class CreateCommandHandler(IVideoRpcWebRequest videoRpcWebRequest) : ICommandHandler<CreateCommand, CreateResponse>
{
    public Task<CreateResponse> HandleAsync(CreateCommand command, CancellationToken cancellationToken) 
        => videoRpcWebRequest.CreateAsync(command, cancellationToken);
}