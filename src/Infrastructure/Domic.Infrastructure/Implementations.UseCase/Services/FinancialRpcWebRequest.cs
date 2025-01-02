using Grpc.Core;
using Grpc.Net.Client;
using Domic.Core.Common.ClassConsts;
using Domic.Core.Financial.Grpc;
using Domic.Core.Infrastructure.Extensions;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Infrastructure.Extensions;
using Domic.UseCase.FinancialUseCase.Contracts.Interfaces;
using Domic.UseCase.FinancialUseCase.Commands.Create;
using Domic.UseCase.FinancialUseCase.Commands.CreateTransactionRequest;
using Domic.UseCase.FinancialUseCase.Commands.PaymentVerification;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

using String                               = Domic.Core.Financial.Grpc.String;
using Int32                                = Domic.Core.Financial.Grpc.Int32;
using Int64                                = Domic.Core.Financial.Grpc.Int64;
using CreateResponse                       = Domic.UseCase.FinancialUseCase.DTOs.GRPCs.Create.CreateResponse;
using CreateResponseBody                   = Domic.UseCase.FinancialUseCase.DTOs.GRPCs.Create.CreateResponseBody;
using CreateRequest                        = Domic.Core.Financial.Grpc.CreateRequest;
using CreateTransactionRequestResponse     = Domic.UseCase.FinancialUseCase.DTOs.GRPCs.CreateTransactionRequest.CreateTransactionRequestResponse;
using CreateTransactionRequestResponseBody = Domic.UseCase.FinancialUseCase.DTOs.GRPCs.CreateTransactionRequest.CreateTransactionRequestResponseBody;
using PaymentVerificationResponse          = Domic.UseCase.FinancialUseCase.DTOs.GRPCs.PaymentVerification.PaymentVerificationResponse;
using PaymentVerificationResponseBody      = Domic.UseCase.FinancialUseCase.DTOs.GRPCs.PaymentVerification.PaymentVerificationResponseBody;

namespace Domic.Infrastructure.Implementations.UseCase.Services;

public class FinancialRpcWebRequest(IServiceDiscovery serviceDiscovery, IConfiguration configuration,
    IHttpContextAccessor httpContextAccessor
) : IFinancialRpcWebRequest
{
    private GrpcChannel _channel;

    public async Task<CreateResponse> CreateAsync(CreateCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        CreateRequest payload = new();

        payload.AccountId       = request.AccountId       != null ? new String { Value = request.AccountId }            : null;
        payload.IncreasedAmount = request.IncreasedAmount != null ? new Int64 { Value = request.IncreasedAmount.Value } : null;
        payload.DecreasedAmount = request.DecreasedAmount != null ? new Int64 { Value = request.DecreasedAmount.Value } : null;
        payload.TransactionType = new Int32 { Value = (int)request.TransactionType };
        
        var result =
            await loadData.client.CreateAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new CreateResponseBody { BankGatewayUrl = result.Body.BankGatewayUrl }
        };
    }

    public async Task<PaymentVerificationResponse> PaymentVerificationAsync(PaymentVerificationCommand request, 
        CancellationToken cancellationToken
    )
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        PaymentVerificationRequest payload = new();

        payload.Amount               = request.Amount               != null ? new Int64 { Value = request.Amount.Value }          : null;
        payload.BankGatewaySecretKey = request.BankGatewaySecretKey != null ? new String { Value = request.BankGatewaySecretKey } : null;
        
        var result =
            await loadData.client.PaymentVerificationAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new PaymentVerificationResponseBody {
                Status = result.Body.Status, 
                TransactionNumber = result.Body.TransactionNumber.Value
            }
        };
    }

    public async Task<CreateTransactionRequestResponse> CreateTransactionRequestAsync(CreateTransactionRequestCommand request, 
        CancellationToken cancellationToken
    )
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        CreateTransactionRequestObject payload = new();

        payload.AccountId = request.AccountId != null ? new String { Value = request.AccountId }    : null;
        payload.Amount    = request.Amount    != null ? new Int64  { Value = request.Amount.Value } : null;
        
        var result =
            await loadData.client.CreateTransactionRequestAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new CreateTransactionRequestResponseBody {
                Result = result.Body.Result
            }
        };
    }

    public void Dispose() => _channel.Dispose();
    
    /*---------------------------------------------------------------*/

    private async Task<(Metadata headers, FinancialService.FinancialServiceClient client)> 
        _loadGrpcChannelAsync(bool isIdempotent, CancellationToken cancellationToken)
    {
        var targetServiceInstance =
            await serviceDiscovery.LoadAddressInMemoryAsync(Service.FinancialService, cancellationToken);
        
        _channel = GrpcChannel.ForAddress(targetServiceInstance, new GrpcChannelOptions().GetAll());
        
        var metaData = new Metadata {
            { Header.Token   , httpContextAccessor.HttpContext.GetRowToken() } ,
            { Header.License , configuration.GetValue<string>("SecretKey") }
        };
        
        if(isIdempotent == false)
            metaData.Add(Header.IdempotentKey, Guid.NewGuid().ToString());
        
        return ( metaData, new FinancialService.FinancialServiceClient(_channel) );
    }
}