using Domic.UseCase.PermissionUseCase.DTOs.ViewModels;

namespace Domic.UseCase.PermissionUseCase.DTOs.GRPCs.ReadOne;

public class ReadOneResponseBody
{
    public PermissionsViewModel Permission { get; set; }
}