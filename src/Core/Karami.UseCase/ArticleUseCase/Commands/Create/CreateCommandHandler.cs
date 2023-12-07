#pragma warning disable CS4014

using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.Core.Common.ClassExtensions;
using Karami.Core.UseCase.Attributes;
using Karami.UseCase.ArticleUseCase.DTOs.GRPCs.Create;
using Karami.UseCase.RoleUseCase.Contracts.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace Karami.UseCase.ArticleUseCase.Commands.Create;

public class CreateCommandHandler : ICommandHandler<CreateCommand, CreateResponse>
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
    public async Task<CreateResponse> HandleAsync(CreateCommand command, CancellationToken cancellationToken)
    {
        #region Upload File

        var image = await command.Image.UploadAsync(_webHostEnvironment, cancellationToken: cancellationToken);

        command.ImageName      = image.name;
        command.ImagePath      = image.path;
        command.ImageExtension = image.extension;

        #endregion

        return await _articleRpcWebRequest.CreateAsync(command, cancellationToken);
    }
}