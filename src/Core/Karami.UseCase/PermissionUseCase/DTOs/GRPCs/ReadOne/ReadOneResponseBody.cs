using Karami.UseCase.PermissionUseCase.DTOs.ViewModels;

namespace Karami.UseCase.PermissionUseCase.DTOs.GRPCs.ReadOne;

public class ReadOneResponseBody
{
    public PermissionsViewModel Permission { get; set; }
}