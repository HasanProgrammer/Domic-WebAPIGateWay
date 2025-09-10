using Domic.UseCase.UserUseCase.DTOs.GRPCs.Create;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.UserUseCase.Commands.Create;

public class CreateCommand : ICommand<CreateResponse>
{
    public string ImageUrl          { get; set; }
    public string Username          { get; set; }
    public string Password          { get; set; }
    public string FirstName         { get; set; }
    public string LastName          { get; set; }
    public string PhoneNumber       { get; set; }
    public string EMail             { get; set; }
    public string Description       { get; set; }
    public List<string> Roles       { get; set; } = new();
    public List<string> Permissions { get; set; } = new();
}