using Domic.UseCase.RoleUseCase.DTOs.ViewModels;

namespace Domic.UseCase.RoleUseCase.DTOs.GRPCs.ReadOne;

public class ReadOneResponseBody
{
    public RolesViewModel Role { get; set; }
}