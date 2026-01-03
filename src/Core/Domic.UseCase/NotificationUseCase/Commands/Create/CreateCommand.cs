using Domic.UseCase.NotificationUseCase.DTOs.GRPCs.Create;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.NotificationUseCase.Commands.Create;

public class CreateCommand : ICommand<CreateResponse>
{
    public string EmailAddress { get; set; }
}