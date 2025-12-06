using Grpc.Core;
using Grpc.Net.Client;
using Domic.Core.Common.ClassConsts;
using Domic.Core.Infrastructure.Extensions;
using Domic.Core.TermComment.Grpc;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Infrastructure.Extensions;
using Domic.UseCase.TermCommentUseCase.Commands.Active;
using Domic.UseCase.TermCommentUseCase.Commands.Create;
using Domic.UseCase.TermCommentUseCase.Commands.Delete;
using Domic.UseCase.TermCommentUseCase.Commands.InActive;
using Domic.UseCase.TermCommentUseCase.Commands.Update;
using Domic.UseCase.TermCommentUseCase.Contracts.Interfaces;
using Microsoft.AspNetCore.Http;

using ActiveRequest        = Domic.Core.TermComment.Grpc.ActiveRequest;
using String               = Domic.Core.TermComment.Grpc.String;
using CreateResponse       = Domic.UseCase.TermCommentUseCase.DTOs.GRPCs.Create.CreateResponse;
using CreateResponseBody   = Domic.UseCase.TermCommentUseCase.DTOs.GRPCs.Create.CreateResponseBody;
using UpdateResponse       = Domic.UseCase.TermCommentUseCase.DTOs.GRPCs.Update.UpdateResponse;
using UpdateResponseBody   = Domic.UseCase.TermCommentUseCase.DTOs.GRPCs.Update.UpdateResponseBody;
using ActiveResponse       = Domic.UseCase.TermCommentUseCase.DTOs.GRPCs.Active.ActiveResponse;
using ActiveResponseBody   = Domic.UseCase.TermCommentUseCase.DTOs.GRPCs.Active.ActiveResponseBody;
using CreateRequest        = Domic.Core.TermComment.Grpc.CreateRequest;
using DeleteRequest        = Domic.Core.TermComment.Grpc.DeleteRequest;
using InActiveResponse     = Domic.UseCase.TermCommentUseCase.DTOs.GRPCs.InActive.InActiveResponse;
using InActiveResponseBody = Domic.UseCase.TermCommentUseCase.DTOs.GRPCs.InActive.InActiveResponseBody;
using DeleteResponse       = Domic.UseCase.TermCommentUseCase.DTOs.GRPCs.Delete.DeleteResponse;
using DeleteResponseBody   = Domic.UseCase.TermCommentUseCase.DTOs.GRPCs.Delete.DeleteResponseBody;
using InActiveRequest      = Domic.Core.TermComment.Grpc.InActiveRequest;
using UpdateRequest        = Domic.Core.TermComment.Grpc.UpdateRequest;

namespace Domic.Infrastructure.Implementations.UseCase.Services;

public class TermCommentRpcWebRequest : ITermCommentRpcWebRequest
{
    private readonly IServiceDiscovery         _serviceDiscovery;
    private readonly IExternalDistributedCache _distributedCache;
    private readonly IHttpContextAccessor      _httpContextAccessor;

    private GrpcChannel _channel;

    public TermCommentRpcWebRequest(IHttpContextAccessor httpContextAccessor,
        IServiceDiscovery serviceDiscovery, IExternalDistributedCache distributedCache
    )
    {
        _httpContextAccessor = httpContextAccessor;
        _serviceDiscovery    = serviceDiscovery;
        _distributedCache    = distributedCache;
    }

    public async Task<CreateResponse> CreateAsync(CreateCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        CreateRequest payload = new();

        payload.TermId  = !string.IsNullOrEmpty(request.TermId)  ? new String { Value = request.TermId }  : null;
        payload.Comment = !string.IsNullOrEmpty(request.Comment) ? new String { Value = request.Comment } : null;

        var result =
            await loadData.client.CreateAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);

        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new CreateResponseBody { CommentId = result.Body.CommentId } 
        };
    }

    public async Task<UpdateResponse> UpdateAsync(UpdateCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        UpdateRequest payload = new();

        payload.CommentId = !string.IsNullOrEmpty(request.Id)      ? new String { Value = request.Id }      : null;
        payload.Comment   = !string.IsNullOrEmpty(request.Comment) ? new String { Value = request.Comment } : null;

        var result =
            await loadData.client.UpdateAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);

        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new UpdateResponseBody { ArticleCommentId = result.Body.CommentId } 
        };
    }

    public async Task<ActiveResponse> ActiveAsync(ActiveCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        ActiveRequest payload = new();

        payload.CommentId = !string.IsNullOrEmpty(request.Id) ? new String { Value = request.Id } : null;

        var result = 
            await loadData.client.ActiveAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);

        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ActiveResponseBody { CommentId = result.Body.CommentId } 
        };
    }

    public async Task<InActiveResponse> InActiveAsync(InActiveCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        InActiveRequest payload = new();

        payload.CommentId = !string.IsNullOrEmpty(request.Id) ? new String { Value = request.Id } : null;

        var result = 
            await loadData.client.InActiveAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);

        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new InActiveResponseBody { ArticleCommentId = result.Body.CommentId } 
        };
    }

    public async Task<DeleteResponse> DeleteAsync(DeleteCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        DeleteRequest payload = new();

        payload.CommentId = !string.IsNullOrEmpty(request.Id) ? new String { Value = request.Id } : null;

        var result = 
            await loadData.client.DeleteAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);

        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new DeleteResponseBody { CommentId = result.Body.CommentId } 
        };
    }

    public void Dispose()
    {
        _channel.Dispose();
    }
    
    /*---------------------------------------------------------------*/

    private async Task<(Metadata headers, TermCommentService.TermCommentServiceClient client)> 
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
        
        return ( metaData, new TermCommentService.TermCommentServiceClient(_channel) );
    }
}