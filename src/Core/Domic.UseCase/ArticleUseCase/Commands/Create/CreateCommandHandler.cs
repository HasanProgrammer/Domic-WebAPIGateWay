#pragma warning disable CS4014

using Domic.UseCase.ArticleUseCase.DTOs.GRPCs.Create;
using Domic.UseCase.RoleUseCase.Contracts.Interfaces;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Core.Common.ClassExtensions;
using Domic.Core.UseCase.Attributes;
using Microsoft.AspNetCore.Hosting;

namespace Domic.UseCase.ArticleUseCase.Commands.Create;

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