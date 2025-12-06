using Domic.UseCase.UserUseCase.Contracts.Interfaces;
using Domic.UseCase.UserUseCase.DTOs.GRPCs.SignIn;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.UserUseCase.Commands.SignIn;

public class SignInCommandHandler : ICommandHandler<SignInCommand, SignInResponse>
{
    private readonly IUserRpcWebRequest _userRpcWebRequest;

    public SignInCommandHandler(IUserRpcWebRequest userRpcWebRequest) => _userRpcWebRequest = userRpcWebRequest;

    public Task BeforeHandleAsync(SignInCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    public Task<SignInResponse> HandleAsync(SignInCommand command, CancellationToken cancellationToken) 
        => _userRpcWebRequest.SignInAsync(command, cancellationToken);

    public Task AfterHandleAsync(SignInCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}