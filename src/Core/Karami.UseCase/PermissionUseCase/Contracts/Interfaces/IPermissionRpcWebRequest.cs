using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.PermissionUseCase.Commands.Create;
using Karami.UseCase.PermissionUseCase.Commands.Delete;
using Karami.UseCase.PermissionUseCase.Commands.Update;
using Karami.UseCase.PermissionUseCase.DTOs.GRPCs.Create;
using Karami.UseCase.PermissionUseCase.DTOs.GRPCs.Delete;
using Karami.UseCase.PermissionUseCase.DTOs.GRPCs.ReadAllPaginated;
using Karami.UseCase.PermissionUseCase.DTOs.GRPCs.ReadOne;
using Karami.UseCase.PermissionUseCase.DTOs.GRPCs.Update;
using Karami.UseCase.PermissionUseCase.Queries.ReadAllPaginated;
using Karami.UseCase.PermissionUseCase.Queries.ReadOne;

namespace Karami.UseCase.RoleUseCase.Contracts.Interfaces;

public interface IPermissionRpcWebRequest : IRpcWebRequest
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<ReadOneResponse> ReadOneAsync(ReadOneQuery request, CancellationToken cancellationToken) 
        => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<ReadAllPaginatedResponse> ReadAllPaginatedAsync(ReadAllPaginatedQuery request,
        CancellationToken cancellationToken
    ) => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<CreateResponse> CreateAsync(CreateCommand request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<UpdateResponse> UpdateAsync(UpdateCommand request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<DeleteResponse> DeleteAsync(DeleteCommand request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}