using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.UserUseCase.Commands.Revoke;

public class RevokeCommand : ICommand<bool>
{
    public bool IsAuthRevoke        { get; set; }
    public string Token             { get; set; } //Username!
    public List<string> Permissions { get; set; }
}