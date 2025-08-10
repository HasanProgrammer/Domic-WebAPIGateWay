using Domic.UseCase.TermCommentAnswerUseCase.Commands.Active;
using Domic.UseCase.TermCommentAnswerUseCase.DTOs.GRPCs.Active;
using Domic.UseCase.TermCommentAnswerUseCase.DTOs.GRPCs.Create;
using Domic.UseCase.TermCommentAnswerUseCase.DTOs.GRPCs.Delete;
using Domic.UseCase.TermCommentAnswerUseCase.DTOs.GRPCs.InActive;
using Domic.UseCase.TermCommentAnswerUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.TermCommentAnswerUseCase.Commands.Create;
using Domic.UseCase.TermCommentAnswerUseCase.Commands.Delete;
using Domic.UseCase.TermCommentAnswerUseCase.Commands.InActive;
using Domic.UseCase.TermCommentAnswerUseCase.Commands.Update;

namespace Domic.UseCase.TermCommentAnswerUseCase.Contracts.Interfaces;

public interface ITermCommentAnswerRpcWebRequest : IRpcWebRequest
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