using Domic.Core.Domain.Contracts.Interfaces;
using Domic.UseCase.UserUseCase.Contracts.Interfaces;
using Domic.UseCase.UserUseCase.DTOs.GRPCs.Active;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.UserUseCase.Commands.Active;

public class ActiveCommandHandler : ICommandHandler<ActiveCommand, ActiveResponse>
{
    private readonly IUserRpcWebRequest _userRpcWebRequest;
    private readonly IExternalDistributedCache _externalDistributedCache;
    private readonly ISerializer _serializer;

    public ActiveCommandHandler(IUserRpcWebRequest userRpcWebRequest,
        IExternalDistributedCache externalDistributedCache, ISerializer serializer
    )
    {
        _userRpcWebRequest = userRpcWebRequest;
        _externalDistributedCache = externalDistributedCache;
        _serializer = serializer;
    }

    public Task BeforeHandleAsync(ActiveCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    public async Task<ActiveResponse> HandleAsync(ActiveCommand command, CancellationToken cancellationToken)
    {
        var result = await _userRpcWebRequest.ActiveAsync(command, cancellationToken);
        
        if (result.Code == 200)
        {
            //todo: shoud be used [Polly] for retry perform below action! ( action = update cache auth )
            
            var blackListAuth = await _externalDistributedCache.GetCacheValueAsync("BlackList-Auth", cancellationToken);
            
            var tokens = new List<string>();

            if (blackListAuth is not null)
                tokens = _serializer.DeSerialize<List<string>>(blackListAuth);

            tokens.Remove(command.Token);
            
            await _externalDistributedCache.SetCacheValueAsync(
                new KeyValuePair<string, string>("BlackList-Auth", _serializer.Serialize(tokens)),
                cancellationToken: cancellationToken
            );
        }

        return result;
    }

    public Task AfterHandleAsync(ActiveCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}