#pragma warning disable CS4014

using Domic.UseCase.ArticleUseCase.DTOs.GRPCs.Update;
using Domic.UseCase.RoleUseCase.Contracts.Interfaces;
using Domic.Core.Common.ClassExtensions;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Core.UseCase.Attributes;
using Microsoft.AspNetCore.Hosting;

namespace Domic.UseCase.ArticleUseCase.Commands.Update;

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

    public Task BeforeHandleAsync(UpdateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

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

    public Task AfterHandleAsync(UpdateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}