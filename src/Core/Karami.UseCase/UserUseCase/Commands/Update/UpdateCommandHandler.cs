using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.UserUseCase.Contracts.Interfaces;
using Karami.UseCase.UserUseCase.DTOs.GRPCs.Update;

namespace Karami.UseCase.UserUseCase.Commands.Update;

public class UpdateCommandHandler : ICommandHandler<UpdateCommand, UpdateResponse>
{
    private readonly IUserRpcWebRequest _userRpcWebRequest;

    public UpdateCommandHandler(IUserRpcWebRequest userRpcWebRequest) 
        => _userRpcWebRequest = userRpcWebRequest;

    public async Task<UpdateResponse> HandleAsync(UpdateCommand command, CancellationToken cancellationToken)
        => await _userRpcWebRequest.UpdateAsync(command, cancellationToken);
}