using Domic.Core.Common.ClassExtensions;
using Domic.Core.UseCase.Attributes;
using Domic.UseCase.VideoUseCase.Contracts.Interfaces;
using Domic.UseCase.VideoUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace Domic.UseCase.VideoUseCase.Commands.Update;

public class UpdateCommandHandler(IVideoRpcWebRequest videoRpcWebRequest, IWebHostEnvironment webHostEnvironment) 
    : ICommandHandler<UpdateCommand, UpdateResponse>
{
    [WithValidation]
    public async Task<UpdateResponse> HandleAsync(UpdateCommand command, CancellationToken cancellationToken)
    {
        #region UploadFile

        var videoInfo = await command.Video.UploadAsync(webHostEnvironment, cancellationToken: cancellationToken);

        command.VideoUrl = videoInfo.path;

        #endregion
        
        return await videoRpcWebRequest.UpdateAsync(command, cancellationToken);
    }
}