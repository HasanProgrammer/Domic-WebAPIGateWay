using Domic.Core.Domain.Contracts.Interfaces;
using Domic.UseCase.UserUseCase.Contracts.Interfaces;
using Domic.UseCase.UserUseCase.DTOs.GRPCs.InActive;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.UserUseCase.Commands.InActive;

public class InActiveCommandHandler : ICommandHandler<InActiveCommand, InActiveResponse>
{
    private readonly IUserRpcWebRequest _userRpcWebRequest;
    private readonly IExternalDistributedCache _externalDistributedCache;
    private readonly ISerializer _serializer;

    public InActiveCommandHandler(IUserRpcWebRequest userRpcWebRequest,
        IExternalDistributedCache externalDistributedCache, ISerializer serializer
    )
    {
        _userRpcWebRequest = userRpcWebRequest;
        _externalDistributedCache = externalDistributedCache;
        _serializer = serializer;
    }

    public Task BeforeHandleAsync(InActiveCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    public async Task<InActiveResponse> HandleAsync(InActiveCommand command, CancellationToken cancellationToken)
    {
        var result = await _userRpcWebRequest.InActiveAsync(command, cancellationToken);

        if (result.Code == 200)
        {
            //todo: shoud be used [Polly] for retry perform below action! ( action = update cache auth )
            
            var blackListAuth = await _externalDistributedCache.GetCacheValueAsync("BlackList-Auth", cancellationToken);
            
            var tokens = new List<string>();

            if (blackListAuth is not null)
                tokens = _serializer.DeSerialize<List<string>>(blackListAuth);
            
            tokens.Add(command.Token);
            
            await _externalDistributedCache.SetCacheValueAsync(
                new KeyValuePair<string, string>("BlackList-Auth", _serializer.Serialize(tokens)),
                cancellationToken: cancellationToken
            );
        }

        return result;
    }

    public Task AfterHandleAsync(InActiveCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}