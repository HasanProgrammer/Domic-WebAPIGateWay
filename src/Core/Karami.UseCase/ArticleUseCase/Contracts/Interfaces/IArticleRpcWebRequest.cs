using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.ArticleUseCase.Commands.Active;
using Karami.UseCase.ArticleUseCase.Commands.Create;
using Karami.UseCase.ArticleUseCase.Commands.Delete;
using Karami.UseCase.ArticleUseCase.Commands.InActive;
using Karami.UseCase.ArticleUseCase.Commands.Update;
using Karami.UseCase.ArticleUseCase.DTOs.GRPCs.Active;
using Karami.UseCase.ArticleUseCase.DTOs.GRPCs.Create;
using Karami.UseCase.ArticleUseCase.DTOs.GRPCs.Delete;
using Karami.UseCase.ArticleUseCase.DTOs.GRPCs.InActive;
using Karami.UseCase.ArticleUseCase.DTOs.GRPCs.ReadAllPaginated;
using Karami.UseCase.ArticleUseCase.DTOs.GRPCs.ReadOne;
using Karami.UseCase.ArticleUseCase.DTOs.GRPCs.Update;
using Karami.UseCase.ArticleUseCase.Queries.ReadAllPaginated;
using Karami.UseCase.ArticleUseCase.Queries.ReadOne;

namespace Karami.UseCase.RoleUseCase.Contracts.Interfaces;

public interface IArticleRpcWebRequest : IRpcWebRequest
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
    public Task<ActiveResponse> ActiveAsync(ActiveCommand request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<InActiveResponse> InActiveAsync(InActiveCommand request, CancellationToken cancellationToken)
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