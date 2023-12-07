using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.ArticleCommentUseCase.Commands.Active;
using Karami.UseCase.ArticleCommentUseCase.Commands.Create;
using Karami.UseCase.ArticleCommentUseCase.Commands.Delete;
using Karami.UseCase.ArticleCommentUseCase.Commands.InActive;
using Karami.UseCase.ArticleCommentUseCase.Commands.Update;
using Karami.UseCase.ArticleCommentUseCase.DTOs.GRPCs.Active;
using Karami.UseCase.ArticleCommentUseCase.DTOs.GRPCs.Create;
using Karami.UseCase.ArticleCommentUseCase.DTOs.GRPCs.Delete;
using Karami.UseCase.ArticleCommentUseCase.DTOs.GRPCs.InActive;
using Karami.UseCase.ArticleCommentUseCase.DTOs.GRPCs.Update;

namespace Karami.UseCase.ArticleCommentUseCase.Contracts.Interfaces;

public interface IArticleCommentRpcWebRequest : IRpcWebRequest
{
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