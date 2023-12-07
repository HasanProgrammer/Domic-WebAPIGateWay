#pragma warning disable CS4014

using Karami.Core.Common.ClassExtensions;
using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.Core.UseCase.Attributes;
using Karami.UseCase.ArticleUseCase.DTOs.GRPCs.Update;
using Karami.UseCase.RoleUseCase.Contracts.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace Karami.UseCase.ArticleUseCase.Commands.Update;

public class CreateCommandHandler : ICommandHandler<UpdateCommand, UpdateResponse>
{
    private readonly IWebHostEnvironment   _webHostEnvironment;
    private readonly IArticleRpcWebRequest _articleRpcWebRequest;

    public CreateCommandHandler(IArticleRpcWebRequest articleRpcWebRequest, 
        IWebHostEnvironment webHostEnvironment
    )
    {
        _webHostEnvironment   = webHostEnvironment;
        _articleRpcWebRequest = articleRpcWebRequest;
    }

    [WithValidation]
    public async Task<UpdateResponse> HandleAsync(UpdateCommand command, CancellationToken cancellationToken)
    {
        #region Upload File

        if (command.Image is not null)
        {
            var image = await command.Image.UploadAsync(_webHostEnvironment, cancellationToken: cancellationToken);

            command.ImageName      = image.name;
            command.ImagePath      = image.path;
            command.ImageExtension = image.extension;
        }

        #endregion

        return await _articleRpcWebRequest.UpdateAsync(command, cancellationToken);
    }
}