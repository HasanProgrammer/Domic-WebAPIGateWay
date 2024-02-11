using Domic.UseCase.UserUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.UserUseCase.Commands.Update;

public class UpdateCommand : ICommand<UpdateResponse>
{
    public string UserId            { get; set; }
    public string Username          { get; set; }
    public string Password          { get; set; }
    public string FirstName         { get; set; }
    public string LastName          { get; set; }
    public string PhoneNumber       { get; set; }
    public string EMail             { get; set; }
    public string Description       { get; set; }
    public bool IsActive            { get; set; }
    public List<string> Roles       { get; set; }
    public List<string> Permissions { get; set; }
}