#pragma warning disable CS4014

using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.CategoryUseCase.DTOs.GRPCs.Create;
using Karami.UseCase.RoleUseCase.Contracts.Interfaces;

namespace Karami.UseCase.CategoryUseCase.Commands.Create;

public class CreateCommandHandler : ICommandHandler<CreateCommand, CreateResponse>
{
    private readonly ICategoryRpcWebRequest _categoryRpcWebRequest;
    
    public CreateCommandHandler(ICategoryRpcWebRequest categoryRpcWebRequest) 
        => _categoryRpcWebRequest = categoryRpcWebRequest;

    public async Task<CreateResponse> HandleAsync(CreateCommand command, CancellationToken cancellationToken)
        => await _categoryRpcWebRequest.CreateAsync(command, cancellationToken);
}