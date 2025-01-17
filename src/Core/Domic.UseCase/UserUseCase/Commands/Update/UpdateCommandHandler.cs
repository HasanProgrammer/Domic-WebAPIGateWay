using Domic.Core.Domain.Contracts.Interfaces;
using Domic.UseCase.UserUseCase.Contracts.Interfaces;
using Domic.UseCase.UserUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Domic.UseCase.UserUseCase.Commands.Update;

public class UpdateCommandHandler : ICommandHandler<UpdateCommand, UpdateResponse>
{
    private readonly IUserRpcWebRequest _userRpcWebRequest;
    private readonly IExternalDistributedCache _externalDistributedCache;
    private readonly ISerializer _serializer;
    private readonly IIdentityUser _identityUser;

    public UpdateCommandHandler(IUserRpcWebRequest userRpcWebRequest, 
        IExternalDistributedCache externalDistributedCache, ISerializer serializer, 
        [FromKeyedServices("Http1")] IIdentityUser identityUser
    )
    {
        _userRpcWebRequest = userRpcWebRequest;
        _externalDistributedCache = externalDistributedCache;
        _serializer = serializer;
        _identityUser = identityUser;
    }

    public Task BeforeHandleAsync(UpdateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    public async Task<UpdateResponse> HandleAsync(UpdateCommand command, CancellationToken cancellationToken)
    {
        var result = await _userRpcWebRequest.UpdateAsync(command, cancellationToken);

        if (result.Code == 200)
            //todo: shoud be used [Polly] for retry perform below action! ( action = update cache permissions )
            await _externalDistributedCache.SetCacheValueAsync(
                new KeyValuePair<string, string>(
                    $"{_identityUser.GetUsername()}-permissions", _serializer.Serialize(result.Body.UserId)
                ),
                cancellationToken: cancellationToken
            );

        return result;
    }

    public Task AfterHandleAsync(UpdateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}