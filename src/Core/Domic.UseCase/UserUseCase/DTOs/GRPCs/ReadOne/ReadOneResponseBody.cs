using Domic.UseCase.UserUseCase.DTOs.ViewModels;

namespace Domic.UseCase.UserUseCase.DTOs.GRPCs.ReadOne;

public class ReadOneResponseBody
{
    public UsersViewModel User { get; set; }
}