using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.UserUseCase.DTOs.GRPCs.SignIn;

namespace Karami.UseCase.UserUseCase.Commands.SignIn;

public class SignInCommand : ICommand<SignInResponse>
{
    public string Username { get; set; }
    public string Password { get; set; }
}