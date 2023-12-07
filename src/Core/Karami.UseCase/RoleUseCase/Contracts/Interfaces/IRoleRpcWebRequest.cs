using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.RoleUseCase.Commands.Create;
using Karami.UseCase.RoleUseCase.Commands.SoftDelete;
using Karami.UseCase.RoleUseCase.Commands.Update;
using Karami.UseCase.RoleUseCase.DTOs.GRPCs.Create;
using Karami.UseCase.RoleUseCase.DTOs.GRPCs.Delete;
using Karami.UseCase.RoleUseCase.DTOs.GRPCs.ReadAllPaginated;
using Karami.UseCase.RoleUseCase.DTOs.GRPCs.ReadOne;
using Karami.UseCase.RoleUseCase.DTOs.GRPCs.Update;
using Karami.UseCase.RoleUseCase.Queries.ReadAllPaginated;
using Karami.UseCase.RoleUseCase.Queries.ReadOne;

namespace Karami.UseCase.RoleUseCase.Contracts.Interfaces;

public interface IRoleRpcWebRequest : IRpcWebRequest
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