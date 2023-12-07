using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.CategoryUseCase.DTOs.GRPCs.Update;
using Karami.UseCase.RoleUseCase.Contracts.Interfaces;

namespace Karami.UseCase.CategoryUseCase.Commands.Update;

public class UpdateCommandHandler : ICommandHandler<UpdateCommand, UpdateResponse>
{
    private readonly ICategoryRpcWebRequest _categoryRpcWebRequest;

    public UpdateCommandHandler(ICategoryRpcWebRequest categoryRpcWebRequest) 
        => _categoryRpcWebRequest = categoryRpcWebRequest;

    public async Task<UpdateResponse> HandleAsync(UpdateCommand command, CancellationToken cancellationToken)
        => await _categoryRpcWebRequest.UpdateAsync(command, cancellationToken);
}