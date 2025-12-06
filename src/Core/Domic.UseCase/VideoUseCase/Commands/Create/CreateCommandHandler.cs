#pragma warning disable CS4014

using Domic.UseCase.VideoUseCase.Contracts.Interfaces;
using Domic.UseCase.VideoUseCase.DTOs.GRPCs.Create;
using Domic.Core.UseCase.Contracts.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace Domic.UseCase.VideoUseCase.Commands.Create;

public class CreateCommandHandler(IVideoRpcWebRequest videoRpcWebRequest, IWebHostEnvironment webHostEnvironment) 
    : ICommandHandler<CreateCommand, CreateResponse>
{
    public Task BeforeHandleAsync(CreateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    public Task<CreateResponse> HandleAsync(CreateCommand command, CancellationToken cancellationToken) 
        => videoRpcWebRequest.CreateAsync(command, cancellationToken);

    public Task AfterHandleAsync(CreateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}