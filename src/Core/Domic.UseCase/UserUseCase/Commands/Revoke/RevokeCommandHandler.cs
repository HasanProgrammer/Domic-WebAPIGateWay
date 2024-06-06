using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.UserUseCase.Commands.Revoke;

public class RevokeCommandHandler : ICommandHandler<RevokeCommand, bool>
{
    private readonly IExternalDistributedCache _redisCache;
    private readonly ISerializer _serializer;

    public RevokeCommandHandler(IExternalDistributedCache redisCache, ISerializer serializer)
    {
        _redisCache = redisCache;
        _serializer = serializer;
    }

    [WithValidation]
    public async Task<bool> HandleAsync(RevokeCommand command, CancellationToken cancellationToken)
    {
        if (command.IsAuthRevoke)
        {
            var result  = await _redisCache.GetCacheValueAsync("BlackList-Auth", cancellationToken);
            var payload = new List<string>();

            if (result is not null)
                payload = _serializer.DeSerialize<List<string>>(result);
            
            payload.Add(command.Token);
            
            await _redisCache.SetCacheValueAsync(
                new KeyValuePair<string, string>("BlackList-Auth", _serializer.Serialize(payload)),
                cancellationToken: cancellationToken
            );
        }

        if (command.Permissions.Count > 0)
        {
            foreach (var permission in command.Permissions)
            {
                var result  = await _redisCache.GetCacheValueAsync($"BlackList-{permission}", cancellationToken);
                var payload = new List<string>();
                
                if (result is not null)
                    payload = _serializer.DeSerialize<List<string>>(result);
                
                payload.Add(command.Token);
                
                await _redisCache.SetCacheValueAsync(
                    new KeyValuePair<string, string>($"BlackList-{permission}", _serializer.Serialize(payload)),
                    cancellationToken: cancellationToken
                );
            }
        }

        return true;
    }
}