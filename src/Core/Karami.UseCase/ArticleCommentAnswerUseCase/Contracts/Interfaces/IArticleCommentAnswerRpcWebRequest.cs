using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.ArticleCommentAnswerUseCase.Commands.Active;
using Karami.UseCase.ArticleCommentAnswerUseCase.Commands.Create;
using Karami.UseCase.ArticleCommentAnswerUseCase.Commands.Delete;
using Karami.UseCase.ArticleCommentAnswerUseCase.Commands.InActive;
using Karami.UseCase.ArticleCommentAnswerUseCase.Commands.Update;
using Karami.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.Active;
using Karami.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.Create;
using Karami.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.Delete;
using Karami.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.Update;
using Karami.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.InActive;

namespace Karami.UseCase.ArticleCommentAnswerUseCase.Contracts.Interfaces;

public interface IArticleCommentAnswerRpcWebRequest : IRpcWebRequest
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