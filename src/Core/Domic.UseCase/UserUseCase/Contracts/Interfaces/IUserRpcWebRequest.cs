using Domic.UseCase.UserUseCase.Commands.Active;
using Domic.UseCase.UserUseCase.Commands.Create;
using Domic.UseCase.UserUseCase.Commands.InActive;
using Domic.UseCase.UserUseCase.Commands.SignIn;
using Domic.UseCase.UserUseCase.Commands.Update;
using Domic.UseCase.UserUseCase.DTOs.GRPCs.Active;
using Domic.UseCase.UserUseCase.DTOs.GRPCs.Create;
using Domic.UseCase.UserUseCase.DTOs.GRPCs.InActive;
using Domic.UseCase.UserUseCase.DTOs.GRPCs.ReadAllPaginated;
using Domic.UseCase.UserUseCase.DTOs.GRPCs.ReadOne;
using Domic.UseCase.UserUseCase.DTOs.GRPCs.SignIn;
using Domic.UseCase.UserUseCase.DTOs.GRPCs.Update;
using Domic.UseCase.UserUseCase.Queries.ReadAllPaginated;
using Domic.UseCase.UserUseCase.Queries.ReadOne;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.UserUseCase.Commands.OtpGeneration;
using Domic.UseCase.UserUseCase.Commands.OtpVerification;
using Domic.UseCase.UserUseCase.DTOs.GRPCs.OtpGeneration;
using Domic.UseCase.UserUseCase.DTOs.GRPCs.OtpVerification;

namespace Domic.UseCase.UserUseCase.Contracts.Interfaces;

public interface IUserRpcWebRequest : IRpcWebRequest
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
    public Task<SignInResponse> SignInAsync(SignInCommand request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<OtpGenerationResponse> OtpGenerationAsync(OtpGenerationCommand request,
        CancellationToken cancellationToken
    ) => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<OtpVerificationResponse> OtpVerificationAsync(OtpVerificationCommand request,
        CancellationToken cancellationToken
    ) => throw new NotImplementedException();
    
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
}