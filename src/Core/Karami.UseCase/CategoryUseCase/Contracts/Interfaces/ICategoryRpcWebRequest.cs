using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.CategoryUseCase.Commands.Create;
using Karami.UseCase.CategoryUseCase.Commands.Delete;
using Karami.UseCase.CategoryUseCase.Commands.Update;
using Karami.UseCase.CategoryUseCase.DTOs.GRPCs.Create;
using Karami.UseCase.CategoryUseCase.DTOs.GRPCs.Delete;
using Karami.UseCase.CategoryUseCase.DTOs.GRPCs.ReadAllPaginated;
using Karami.UseCase.CategoryUseCase.DTOs.GRPCs.ReadOne;
using Karami.UseCase.CategoryUseCase.DTOs.GRPCs.Update;
using Karami.UseCase.CategoryUseCase.Queries.ReadAllPaginated;
using Karami.UseCase.CategoryUseCase.Queries.ReadOne;

namespace Karami.UseCase.RoleUseCase.Contracts.Interfaces;

public interface ICategoryRpcWebRequest : IRpcWebRequest
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