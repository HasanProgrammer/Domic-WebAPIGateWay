using Domic.UseCase.FinancialUseCase.DTOs.GRPCs.Create;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.FinancialUseCase.Commands.ChangeStatusTransactionRequest;
using Domic.UseCase.FinancialUseCase.Commands.Create;
using Domic.UseCase.FinancialUseCase.Commands.CreateTransactionRequest;
using Domic.UseCase.FinancialUseCase.Commands.DecreaseAccountBalance;
using Domic.UseCase.FinancialUseCase.Commands.PaymentVerification;
using Domic.UseCase.FinancialUseCase.DTOs.GRPCs.ChangeStatusTransactionRequest;
using Domic.UseCase.FinancialUseCase.DTOs.GRPCs.CreateTransactionRequest;
using Domic.UseCase.FinancialUseCase.DTOs.GRPCs.DecreaseAccountBalance;
using Domic.UseCase.FinancialUseCase.DTOs.GRPCs.PaymentVerification;

namespace Domic.UseCase.FinancialUseCase.Contracts.Interfaces;

public interface IFinancialRpcWebRequest : IRpcWebRequest
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<CreateResponse> CreateAsync(CreateCommand request, CancellationToken cancellationToken);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<PaymentVerificationResponse> PaymentVerificationAsync(PaymentVerificationCommand request,
        CancellationToken cancellationToken
    );

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<CreateTransactionRequestResponse> CreateTransactionRequestAsync(CreateTransactionRequestCommand request,
        CancellationToken cancellationToken
    );
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<ChangeStatusTransactionRequestResponse> ChangeStatusTransactionRequestAsync(ChangeStatusTransactionRequestCommand request,
        CancellationToken cancellationToken
    );
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<DecreaseAccountBalanceResponse> DecreaseAccountBalanceAsync(DecreaseAccountBalanceCommand request,
        CancellationToken cancellationToken
    );
}