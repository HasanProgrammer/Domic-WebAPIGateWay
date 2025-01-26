using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.UserUseCase.DTOs.GRPCs.OtpGeneration;

namespace Domic.UseCase.UserUseCase.Commands.OtpGeneration;

public class OtpGenerationCommand : ICommand<OtpGenerationResponse>
{
    public string PhoneNumber { get; set; }
}