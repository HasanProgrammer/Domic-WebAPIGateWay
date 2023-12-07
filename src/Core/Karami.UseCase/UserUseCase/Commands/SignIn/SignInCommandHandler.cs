using Karami.Core.Common.ClassConsts;
using Karami.Core.Domain.Contracts.Interfaces;
using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.UserUseCase.Contracts.Interfaces;
using Karami.UseCase.UserUseCase.DTOs.GRPCs.SignIn;

namespace Karami.UseCase.UserUseCase.Commands.SignIn;

public class SignInCommandHandler : ICommandHandler<SignInCommand, SignInResponse>
{
    private readonly IRedisCache        _redisCache;
    private readonly ISerializer        _serializer;
    private readonly IJsonWebToken      _jsonWebToken;
    private readonly IUserRpcWebRequest _userRpcWebRequest;

    public SignInCommandHandler(IUserRpcWebRequest userRpcWebRequest, IRedisCache redisCache, ISerializer serializer,
        IJsonWebToken jsonWebToken
    )
    {
        _redisCache        = redisCache;
        _serializer        = serializer;
        _jsonWebToken      = jsonWebToken;
        _userRpcWebRequest = userRpcWebRequest;
    }

    public async Task<SignInResponse> HandleAsync(SignInCommand command, CancellationToken cancellationToken)
    {
        var result = await _userRpcWebRequest.SignInAsync(command, cancellationToken);

        if (result.Code == 200)
        {
            var blackListAuth = _redisCache.GetCacheValue("BlackList-Auth");
            var userUsername  = _jsonWebToken.GetUsername(result.Body.Token);

            if (!string.IsNullOrEmpty(blackListAuth))
            {
                var userUsernames = _serializer.DeSerialize<List<string>>( blackListAuth );

                if (userUsernames.Contains(userUsername))
                {
                    var targetUsername = userUsernames.Find(username => username.Equals(userUsername));

                    userUsernames.Remove(targetUsername);
                    
                    _redisCache.SetCacheValue(
                        new KeyValuePair<string, string>("BlackList-Auth",
                            _serializer.Serialize(userUsernames)
                        )
                    );
                }
            }
            
            foreach (var permission in Permission.GetAll())
            {
                var blackListPermission = _redisCache.GetCacheValue($"BlackList-{permission}");

                if (!string.IsNullOrEmpty(blackListPermission))
                {
                    var userUsernames = _serializer.DeSerialize<List<string>>( blackListPermission );

                    if (userUsernames.Contains(userUsername))
                    {
                        var targetUsername = userUsernames.Find(username => username.Equals(userUsername));

                        userUsernames.Remove(targetUsername);
                    
                        _redisCache.SetCacheValue(
                            new KeyValuePair<string, string>($"BlackList-{permission}",
                                _serializer.Serialize(userUsernames)
                            )
                        );
                    }
                }
            }
        }

        return result;
    }
}