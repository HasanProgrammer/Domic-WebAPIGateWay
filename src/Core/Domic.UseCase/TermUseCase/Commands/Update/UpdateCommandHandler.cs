using Domic.Core.Common.ClassExtensions;
using Domic.Core.UseCase.Attributes;
using Domic.UseCase.TermUseCase.Contracts.Interfaces;
using Domic.UseCase.TermUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace Domic.UseCase.TermUseCase.Commands.Update;

public class UpdateCommandHandler(ITermRpcWebRequest termRpcWebRequest, IWebHostEnvironment webHostEnvironment) 
    : ICommandHandler<UpdateCommand, UpdateResponse>
{
    [WithValidation]
    public async Task<UpdateResponse> HandleAsync(UpdateCommand command, CancellationToken cancellationToken)
    {
        #region UploadFile

        if (command.Image is not null)
        {
            var imageInfo = await command.Image.UploadAsync(webHostEnvironment, cancellationToken: cancellationToken);

            command.ImageUrl = imageInfo.path;
        }

        #endregion
        
       return await termRpcWebRequest.UpdateAsync(command, cancellationToken);
    }
}