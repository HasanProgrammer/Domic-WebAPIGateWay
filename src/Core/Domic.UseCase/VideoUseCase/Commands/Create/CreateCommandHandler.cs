#pragma warning disable CS4014

using Domic.Core.Common.ClassExtensions;
using Domic.Core.UseCase.Attributes;
using Domic.UseCase.VideoUseCase.Contracts.Interfaces;
using Domic.UseCase.VideoUseCase.DTOs.GRPCs.Create;
using Domic.Core.UseCase.Contracts.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace Domic.UseCase.VideoUseCase.Commands.Create;

public class CreateCommandHandler(IVideoRpcWebRequest videoRpcWebRequest, IWebHostEnvironment webHostEnvironment) 
    : ICommandHandler<CreateCommand, CreateResponse>
{
    public Task BeforeHandleAsync(CreateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    [WithValidation]
    public async Task<CreateResponse> HandleAsync(CreateCommand command, CancellationToken cancellationToken)
    {
        #region UploadFile

        var videoInfo = await command.Video.UploadAsync(webHostEnvironment, cancellationToken: cancellationToken);

        command.VideoUrl = videoInfo.path;

        #endregion
        
        return await videoRpcWebRequest.CreateAsync(command, cancellationToken);
    }

    public Task AfterHandleAsync(CreateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}