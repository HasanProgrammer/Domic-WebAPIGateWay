using Grpc.Core;
using Grpc.Net.Client;
using Domic.Core.Common.ClassConsts;
using Domic.Core.Infrastructure.Extensions;
using Domic.Core.TermCommentAnswer.Grpc;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Infrastructure.Extensions;
using Domic.UseCase.TermCommentAnswerUseCase.Commands.Active;
using Domic.UseCase.TermCommentAnswerUseCase.Commands.Create;
using Domic.UseCase.TermCommentAnswerUseCase.Commands.Delete;
using Domic.UseCase.TermCommentAnswerUseCase.Commands.InActive;
using Domic.UseCase.TermCommentAnswerUseCase.Commands.Update;
using Domic.UseCase.TermCommentAnswerUseCase.Contracts.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

using ActiveRequest        = Domic.Core.TermCommentAnswer.Grpc.ActiveRequest;
using String               = Domic.Core.TermCommentAnswer.Grpc.String;
using CreateResponse       = Domic.UseCase.TermCommentAnswerUseCase.DTOs.GRPCs.Create.CreateResponse;
using CreateResponseBody   = Domic.UseCase.TermCommentAnswerUseCase.DTOs.GRPCs.Create.CreateResponseBody;
using UpdateResponse       = Domic.UseCase.TermCommentAnswerUseCase.DTOs.GRPCs.Update.UpdateResponse;
using UpdateResponseBody   = Domic.UseCase.TermCommentAnswerUseCase.DTOs.GRPCs.Update.UpdateResponseBody;
using ActiveResponse       = Domic.UseCase.TermCommentAnswerUseCase.DTOs.GRPCs.Active.ActiveResponse;
using ActiveResponseBody   = Domic.UseCase.TermCommentAnswerUseCase.DTOs.GRPCs.Active.ActiveResponseBody;
using CreateRequest        = Domic.Core.TermCommentAnswer.Grpc.CreateRequest;
using DeleteRequest        = Domic.Core.TermCommentAnswer.Grpc.DeleteRequest;
using InActiveResponse     = Domic.UseCase.TermCommentAnswerUseCase.DTOs.GRPCs.InActive.InActiveResponse;
using InActiveResponseBody = Domic.UseCase.TermCommentAnswerUseCase.DTOs.GRPCs.InActive.InActiveResponseBody;
using DeleteResponse       = Domic.UseCase.TermCommentAnswerUseCase.DTOs.GRPCs.Delete.DeleteResponse;
using DeleteResponseBody   = Domic.UseCase.TermCommentAnswerUseCase.DTOs.GRPCs.Delete.DeleteResponseBody;
using InActiveRequest      = Domic.Core.TermCommentAnswer.Grpc.InActiveRequest;
using UpdateRequest        = Domic.Core.TermCommentAnswer.Grpc.UpdateRequest;

namespace Domic.Infrastructure.Implementations.UseCase.Services;

public class TermCommentAnswerRpcWebRequest : ITermCommentAnswerRpcWebRequest
{
    private readonly IServiceDiscovery         _serviceDiscovery;
    private readonly IExternalDistributedCache _distributedCache;
    private readonly IHttpContextAccessor      _httpContextAccessor;
    private readonly IConfiguration            _configuration;
    
    private GrpcChannel _channel;

    public TermCommentAnswerRpcWebRequest(IConfiguration configuration, IHttpContextAccessor httpContextAccessor,
        IServiceDiscovery serviceDiscovery, IExternalDistributedCache distributedCache
    )
    {
        _configuration       = configuration;
        _httpContextAccessor = httpContextAccessor;
        _serviceDiscovery    = serviceDiscovery;
        _distributedCache    = distributedCache;
    }

    public async Task<CreateResponse> CreateAsync(CreateCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        CreateRequest payload = new() {
            CommentId = request.CommentId is not null ? new String { Value = request.CommentId } : null ,
            Answer    = request.Answer    is not null ? new String { Value = request.Answer }    : null
        };

        var result =
            await loadData.client.CreateAsync(payload, cancellationToken: cancellationToken, headers: loadData.headers);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new CreateResponseBody { AnswerId = result.Body.AnswerId }
        };
    }

    public async Task<UpdateResponse> UpdateAsync(UpdateCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        UpdateRequest payload = new() {
            AnswerId = request.Id     is not null ? new String { Value = request.Id }     : null ,
            Answer   = request.Answer is not null ? new String { Value = request.Answer } : null
        };

        var result = 
            await loadData.client.UpdateAsync(payload, cancellationToken: cancellationToken, headers: loadData.headers);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new UpdateResponseBody { AnswerId = result.Body.AnswerId }
        };
    }

    public async Task<ActiveResponse> ActiveAsync(ActiveCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        ActiveRequest payload = new() {
            AnswerId = request.Id is not null ? new String { Value = request.Id } : null
        };

        var result = 
            await loadData.client.ActiveAsync(payload, cancellationToken: cancellationToken, headers: loadData.headers);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ActiveResponseBody { AnswerId = result.Body.AnswerId }
        };
    }

    public async Task<InActiveResponse> InActiveAsync(InActiveCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        InActiveRequest payload = new() {
            AnswerId = request.Id is not null ? new String { Value = request.Id } : null
        };

        var result =
            await loadData.client.InActiveAsync(payload, cancellationToken: cancellationToken, headers: loadData.headers);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new InActiveResponseBody { AnswerId = result.Body.AnswerId }
        };
    }

    public async Task<DeleteResponse> DeleteAsync(DeleteCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        DeleteRequest payload = new() {
            AnswerId = request.Id is not null ? new String { Value = request.Id } : null
        };

        var result =
            await loadData.client.DeleteAsync(payload, cancellationToken: cancellationToken, headers: loadData.headers);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new DeleteResponseBody { AnswerId = result.Body.AnswerId }
        };
    }

    public void Dispose()
    {
        _channel.Dispose();
    }
    
    /*---------------------------------------------------------------*/

    private async Task<(Metadata headers, TermCommentAnswerService.TermCommentAnswerServiceClient client)> 
        _loadGrpcChannelAsync(bool isIdempotent, CancellationToken cancellationToken)
    {
        var targetServiceInstanceTask =
            _serviceDiscovery.LoadAddressInMemoryAsync(Service.CommentService, cancellationToken);
        
        var secretKeyTask = _distributedCache.GetCacheValueAsync("SecretKey", cancellationToken);

        await Task.WhenAll(targetServiceInstanceTask, secretKeyTask);
        
        _channel = GrpcChannel.ForAddress(await targetServiceInstanceTask, new GrpcChannelOptions().GetAll());

        var metaData = new Metadata {
            { Header.Token   , _httpContextAccessor.HttpContext.GetRowToken() } ,
            { Header.License , await secretKeyTask }
        };
        
        if(isIdempotent == false)
            metaData.Add(Header.IdempotentKey, Guid.NewGuid().ToString());
        
        return (metaData, new TermCommentAnswerService.TermCommentAnswerServiceClient(_channel) );
    }
}