using Karami.Core.Domain.Contracts.Interfaces;
using Karami.Core.UseCase.Attributes;
using Karami.Core.UseCase.Contracts.Interfaces;

namespace Karami.UseCase.UserUseCase.Commands.Revoke;

public class RevokeCommandHandler : ICommandHandler<RevokeCommand, bool>
{
    private readonly IRedisCache _redisCache;
    private readonly ISerializer _serializer;

    public RevokeCommandHandler(IRedisCache redisCache, ISerializer serializer)
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
                cancellationToken
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
                    cancellationToken
                );
            }
        }

        return true;
    }
}