#pragma warning disable CS4014

using Domic.UseCase.CategoryUseCase.DTOs.GRPCs.Create;
using Domic.UseCase.RoleUseCase.Contracts.Interfaces;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.CategoryUseCase.Commands.Create;

public class CreateCommandHandler : ICommandHandler<CreateCommand, CreateResponse>
{
    private readonly ICategoryRpcWebRequest _categoryRpcWebRequest;
    
    public CreateCommandHandler(ICategoryRpcWebRequest categoryRpcWebRequest) 
        => _categoryRpcWebRequest = categoryRpcWebRequest;

    public async Task<CreateResponse> HandleAsync(CreateCommand command, CancellationToken cancellationToken)
        => await _categoryRpcWebRequest.CreateAsync(command, cancellationToken);
}