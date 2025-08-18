﻿using Grpc.Core;
using Grpc.Net.Client;
using Domic.Core.Common.ClassConsts;
using Domic.Core.Common.ClassHelpers;
using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.Financial.Grpc;
using Domic.Core.Infrastructure.Extensions;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Infrastructure.Extensions;
using Domic.UseCase.FinancialUseCase.Commands.ChangeStatusTransactionRequest;
using Domic.UseCase.FinancialUseCase.Contracts.Interfaces;
using Domic.UseCase.FinancialUseCase.Commands.Create;
using Domic.UseCase.FinancialUseCase.Commands.CreateTransactionRequest;
using Domic.UseCase.FinancialUseCase.Commands.DecreaseAccountBalance;
using Domic.UseCase.FinancialUseCase.Commands.PaymentVerification;
using Domic.UseCase.FinancialUseCase.DTOs.GRPCs.DecreaseAccountBalance;
using Domic.UseCase.FinancialUseCase.DTOs.GRPCs.ReadAllTransactionPaginated;
using Domic.UseCase.FinancialUseCase.DTOs.GRPCs.ReadAllTransactionRequestPaginated;
using Domic.UseCase.FinancialUseCase.Queries.ReadAllTransactionPaginated;
using Domic.UseCase.FinancialUseCase.Queries.ReadAllTransactionRequestPaginated;
using Domic.UseCase.FinancialUseCase.Queries.ReadCurrentUserBalence;
using Google.Protobuf.Collections;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using String                                         = Domic.Core.Financial.Grpc.String;
using Int32                                          = Domic.Core.Financial.Grpc.Int32;
using Int64                                          = Domic.Core.Financial.Grpc.Int64;
using CreateResponse                                 = Domic.UseCase.FinancialUseCase.DTOs.GRPCs.Create.CreateResponse;
using CreateResponseBody                             = Domic.UseCase.FinancialUseCase.DTOs.GRPCs.Create.CreateResponseBody;
using CreateRequest                                  = Domic.Core.Financial.Grpc.CreateRequest;
using CreateTransactionRequestResponse               = Domic.UseCase.FinancialUseCase.DTOs.GRPCs.CreateTransactionRequest.CreateTransactionRequestResponse;
using CreateTransactionRequestResponseBody           = Domic.UseCase.FinancialUseCase.DTOs.GRPCs.CreateTransactionRequest.CreateTransactionRequestResponseBody;
using PaymentVerificationResponse                    = Domic.UseCase.FinancialUseCase.DTOs.GRPCs.PaymentVerification.PaymentVerificationResponse;
using PaymentVerificationResponseBody                = Domic.UseCase.FinancialUseCase.DTOs.GRPCs.PaymentVerification.PaymentVerificationResponseBody;
using ChangeStatusTransactionRequestResponse         = Domic.UseCase.FinancialUseCase.DTOs.GRPCs.ChangeStatusTransactionRequest.ChangeStatusTransactionRequestResponse;
using ChangeStatusTransactionRequestResponseBody     = Domic.UseCase.FinancialUseCase.DTOs.GRPCs.ChangeStatusTransactionRequest.ChangeStatusTransactionRequestResponseBody;
using CurrentBalenceResponse                         = Domic.UseCase.FinancialUseCase.DTOs.GRPCs.ReadAllTransactionPaginated.CurrentBalenceResponse;
using CurrentBalenceResponseBody                     = Domic.UseCase.FinancialUseCase.DTOs.GRPCs.ReadAllTransactionPaginated.CurrentBalenceResponseBody;
using ReadAllTransactionRequestPaginatedResponse     = Domic.UseCase.FinancialUseCase.DTOs.GRPCs.ReadAllTransactionRequestPaginated.ReadAllTransactionRequestPaginatedResponse;
using ReadAllTransactionRequestPaginatedResponseBody = Domic.UseCase.FinancialUseCase.DTOs.GRPCs.ReadAllTransactionRequestPaginated.ReadAllTransactionRequestPaginatedResponseBody;

namespace Domic.Infrastructure.Implementations.UseCase.Services;

public class FinancialRpcWebRequest(IServiceDiscovery serviceDiscovery,
    IHttpContextAccessor httpContextAccessor, IExternalDistributedCache distributedCache,
    [FromKeyedServices("Http1")] IIdentityUser identityUser
) : IFinancialRpcWebRequest
{
    private GrpcChannel _channel;

    public async Task<CurrentBalenceResponse> CurrentBalenceAsync(ReadCurrentUserBalenceQuery request,
        CancellationToken cancellationToken
    )
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        CurrentBalenceRequest payload = new();
        
        var result =
            await loadData.client.CurrentBalenceAsync(payload, headers: loadData.headers, 
                cancellationToken: cancellationToken
            );

        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new CurrentBalenceResponseBody { Amount = result.Body.Amount }
        };
    }

    public async Task<ReadAllTransactionPaginatedResponse> ReadAllTransactionPaginatedAsync(ReadAllTransactionPaginatedQuery request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        ReadAllTransactionRequest payload = new();

        payload.Sort = new Int32 { Value = Convert.ToInt32(request.Sort) };
        payload.PageNumber = request.PageNumber != null ? new Int32 { Value = request.PageNumber.Value } : default;
        payload.CountPerPage = request.CountPerPage != null ? new Int32 { Value = request.CountPerPage.Value } : default;
        payload.SearchText = !string.IsNullOrEmpty(request.SearchText) ? new String { Value = request.SearchText } : default;

        if (!identityUser.GetRoles().Contains("SuperAdmin") && !identityUser.GetRoles().Contains("Admin"))
            payload.UserId = new String { Value = identityUser.GetIdentity() };
        else
            payload.UserId = default;
        
        var result =
            await loadData.client.ReadAllTransactionPaginatedAsync(payload, headers: loadData.headers, 
                cancellationToken: cancellationToken
            );
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ReadAllTransactionPaginatedResponseBody {
                Transactions = result.Body.Transactions.DeSerialize<PaginatedCollection<TransactionDto>>()
            }
        };
    }

    public async Task<ReadAllTransactionRequestPaginatedResponse> ReadAllTransactionRequestPaginatedAsync(
        ReadAllTransactionRequestPaginatedQuery request, CancellationToken cancellationToken
    )
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        ReadAllTransactionRequestPaginatedObject payload = new();

        payload.Sort = new Int32 { Value = Convert.ToInt32(request.Sort) };
        payload.PageNumber = request.PageNumber != null ? new Int32 { Value = request.PageNumber.Value } : default;
        payload.CountPerPage = request.CountPerPage != null ? new Int32 { Value = request.CountPerPage.Value } : default;
        payload.SearchText = !string.IsNullOrEmpty(request.SearchText) ? new String { Value = request.SearchText } : default;

        if (!identityUser.GetRoles().Contains("SuperAdmin") && !identityUser.GetRoles().Contains("Admin"))
            payload.UserId = new String { Value = identityUser.GetIdentity() };
        else
            payload.UserId = default;
        
        var result =
            await loadData.client.ReadAllTransactionRequestPaginatedAsync(payload, headers: loadData.headers, 
                cancellationToken: cancellationToken
            );
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ReadAllTransactionRequestPaginatedResponseBody {
                TransactionRequests = result.Body.TransactionRequests.DeSerialize<PaginatedCollection<TransactionRequestDto>>()
            }
        };
    }

    public async Task<CreateResponse> CreateAsync(CreateCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        CreateRequest payload = new();
        
        payload.AccountId       = request.AccountId       != null ? new String { Value = request.AccountId }            : null;
        payload.IncreasedAmount = request.IncreasedAmount != null ? new Int64 { Value = request.IncreasedAmount.Value } : null;
        payload.DecreasedAmount = request.DecreasedAmount != null ? new Int64 { Value = request.DecreasedAmount.Value } : null;
        payload.TransactionType = new Int32 { Value = (int)request.TransactionType };
        
        payload.Items.AddRange(request.Items);
        
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

    public async Task<ChangeStatusTransactionRequestResponse> ChangeStatusTransactionRequestAsync(
        ChangeStatusTransactionRequestCommand request, CancellationToken cancellationToken
    )
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        ChangeStatusTransactionRequestObject payload = new();

        payload.Id = !string.IsNullOrEmpty(request.Id) ? new String { Value = request.Id } : null;
        payload.Status = new Int32 { Value = (int)request.Status };
        payload.RejectReason = !string.IsNullOrEmpty(request.RejectReason) ? new String { Value = request.RejectReason } : null;
        payload.BankTransferReceiptImage = !string.IsNullOrEmpty(request.BankTransferReceiptImage) ? new String { Value = request.BankTransferReceiptImage } : null;
        
        var result =
            await loadData.client.ChangeStatusTransactionRequestAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ChangeStatusTransactionRequestResponseBody {
                Result = result.Body.Result
            }
        };
    }

    public async Task<DecreaseAccountBalanceResponse> DecreaseAccountBalanceAsync(DecreaseAccountBalanceCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        DecreaseBalanceOfWalletRequest payload = new();

        payload.AccountId = !string.IsNullOrEmpty(request.AccountId) ? new String { Value = request.AccountId } : default;
        payload.Value = request.Value != null ? new Int64 { Value = request.Value.Value } : default;
        
        var result =
            await loadData.client.DecreaseBalanceOfWalletAsync(payload, headers: loadData.headers, 
                cancellationToken: cancellationToken
            );
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new DecreaseAccountBalanceResponseBody {
                Result = result.Body.Result
            }
        };
    }

    public void Dispose() => _channel.Dispose();
    
    /*---------------------------------------------------------------*/

    private async Task<(Metadata headers, FinancialService.FinancialServiceClient client)> 
        _loadGrpcChannelAsync(bool isIdempotent, CancellationToken cancellationToken)
    {
        var targetServiceInstanceTask = 
            serviceDiscovery.LoadAddressInMemoryAsync(Service.FinancialService, cancellationToken);
        
        var secretKeyTask = distributedCache.GetCacheValueAsync("SecretKey", cancellationToken);

        await Task.WhenAll(targetServiceInstanceTask, secretKeyTask);
        
        _channel = GrpcChannel.ForAddress(await targetServiceInstanceTask, new GrpcChannelOptions().GetAll());
        
        var metaData = new Metadata {
            { Header.Token   , httpContextAccessor.HttpContext.GetRowToken() } ,
            { Header.License , await secretKeyTask }
        };
        
        if(isIdempotent == false)
            metaData.Add(Header.IdempotentKey, Guid.NewGuid().ToString());
        
        return ( metaData, new FinancialService.FinancialServiceClient(_channel) );
    }
}