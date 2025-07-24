using Domic.UseCase.UserUseCase.DTOs.GRPCs.SignIn;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.UserUseCase.Commands.SignIn;

public class SignInCommand : ICommand<SignInResponse>
{
    public string Username { get; set; }
    public string Password { get; set; }
}