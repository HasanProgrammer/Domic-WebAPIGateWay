#pragma warning disable CS4014

using Domic.Core.Common.ClassExtensions;
using Domic.Core.UseCase.Attributes;
using Domic.UseCase.TermUseCase.Contracts.Interfaces;
using Domic.UseCase.TermUseCase.DTOs.GRPCs.Create;
using Domic.Core.UseCase.Contracts.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace Domic.UseCase.TermUseCase.Commands.Create;

public class CreateCommandHandler(ITermRpcWebRequest termRpcWebRequest,
    IWebHostEnvironment webHostEnvironment
) : ICommandHandler<CreateCommand, CreateResponse>
{
    public Task BeforeHandleAsync(CreateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    [WithValidation]
    public async Task<CreateResponse> HandleAsync(CreateCommand command, CancellationToken cancellationToken)
    {
        #region UploadFile

        var imageInfo = await command.Image.UploadAsync(webHostEnvironment, cancellationToken: cancellationToken);

        command.ImageUrl = imageInfo.path;

        #endregion
        
        return await termRpcWebRequest.CreateAsync(command, cancellationToken);
    }

    public Task AfterHandleAsync(CreateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}