using Karami.Core.UseCase.Contracts.Interfaces;

namespace Karami.UseCase.UserUseCase.Commands.Revoke;

public class RevokeCommand : ICommand<bool>
{
    public bool IsAuthRevoke        { get; set; }
    public string Token             { get; set; } //Username!
    public List<string> Permissions { get; set; }
}