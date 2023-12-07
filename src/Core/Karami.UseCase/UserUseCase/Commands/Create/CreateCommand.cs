using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.UserUseCase.DTOs.GRPCs.Create;

namespace Karami.UseCase.UserUseCase.Commands.Create;

public class CreateCommand : ICommand<CreateResponse>
{
    public string Username          { get; set; }
    public string Password          { get; set; }
    public string FirstName         { get; set; }
    public string LastName          { get; set; }
    public string PhoneNumber       { get; set; }
    public string EMail             { get; set; }
    public string Description       { get; set; }
    public List<string> Roles       { get; set; }
    public List<string> Permissions { get; set; }
}