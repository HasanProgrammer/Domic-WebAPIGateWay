using Grpc.Core;
using Grpc.Net.Client;
using Karami.Core.Common.ClassConsts;
using Karami.Core.Grpc.ArticleCommentAnswer;
using Karami.Core.Infrastructure.Extensions;
using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.Infrastructure.Extensions;
using Karami.UseCase.ArticleCommentAnswerUseCase.Commands.Active;
using Karami.UseCase.ArticleCommentAnswerUseCase.Commands.Create;
using Karami.UseCase.ArticleCommentAnswerUseCase.Commands.Delete;
using Karami.UseCase.ArticleCommentAnswerUseCase.Commands.InActive;
using Karami.UseCase.ArticleCommentAnswerUseCase.Commands.Update;
using Karami.UseCase.ArticleCommentAnswerUseCase.Contracts.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

using String               = Karami.Core.Grpc.ArticleCommentAnswer.String;
using CreateResponse       = Karami.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.Create.CreateResponse;
using CreateResponseBody   = Karami.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.Create.CreateResponseBody;
using UpdateResponse       = Karami.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.Update.UpdateResponse;
using UpdateResponseBody   = Karami.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.Update.UpdateResponseBody;
using ActiveResponse       = Karami.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.Active.ActiveResponse;
using ActiveResponseBody   = Karami.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.Active.ActiveResponseBody;
using InActiveResponse     = Karami.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.InActive.InActiveResponse;
using InActiveResponseBody = Karami.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.InActive.InActiveResponseBody;
using DeleteResponse       = Karami.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.Delete.DeleteResponse;
using DeleteResponseBody   = Karami.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.Delete.DeleteResponseBody;

namespace Karami.Infrastructure.Implementations.UseCase.Services;

public class ArticleCommentAnswerRpcWebRequest : IArticleCommentAnswerRpcWebRequest
{
    private readonly IServiceDiscovery    _serviceDiscovery;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IConfiguration       _configuration;
    
    private GrpcChannel _channel;

    public ArticleCommentAnswerRpcWebRequest(IConfiguration configuration, IHttpContextAccessor httpContextAccessor,
        IServiceDiscovery serviceDiscovery
    )
    {
        _configuration       = configuration;
        _httpContextAccessor = httpContextAccessor;
        _serviceDiscovery    = serviceDiscovery;
    }

    public async Task<CreateResponse> CreateAsync(CreateCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(cancellationToken);
        
        CreateRequest payload = new() {
            OwnerId   = request.OwnerId   is not null ? new String { Value = request.OwnerId }   : null ,
            CommentId = request.CommentId is not null ? new String { Value = request.CommentId } : null ,
            Answer    = request.Answer    is not null ? new String { Value = request.Answer }    : null
        };

        var result =
            await loadData.client.CreateAsync(payload, cancellationToken: cancellationToken, headers: loadData.headers);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new CreateResponseBody { ArticleCommentAnswerId = result.Body.AnswerId }
        };
    }

    public async Task<UpdateResponse> UpdateAsync(UpdateCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(cancellationToken);
        
        UpdateRequest payload = new() {
            TargetId = request.TargetId is not null ? new String { Value = request.TargetId } : null ,
            Answer   = request.Answer   is not null ? new String { Value = request.Answer }   : null
        };

        var result = 
            await loadData.client.UpdateAsync(payload, cancellationToken: cancellationToken, headers: loadData.headers);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new UpdateResponseBody { ArticleCommentAnswerId = result.Body.AnswerId }
        };
    }

    public async Task<ActiveResponse> ActiveAsync(ActiveCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(cancellationToken);
        
        ActiveRequest payload = new() {
            TargetId = request.TargetId is not null ? new String { Value = request.TargetId } : null
        };

        var result = 
            await loadData.client.ActiveAsync(payload, cancellationToken: cancellationToken, headers: loadData.headers);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ActiveResponseBody { ArticleCommentAnswerId = result.Body.AnswerId }
        };
    }

    public async Task<InActiveResponse> InActiveAsync(InActiveCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(cancellationToken);
        
        InActiveRequest payload = new() {
            TargetId = request.TargetId is not null ? new String { Value = request.TargetId } : null
        };

        var result =
            await loadData.client.InActiveAsync(payload, cancellationToken: cancellationToken, headers: loadData.headers);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new InActiveResponseBody { ArticleCommentAnswerId = result.Body.AnswerId }
        };
    }

    public async Task<DeleteResponse> DeleteAsync(DeleteCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(cancellationToken);
        
        DeleteRequest payload = new() {
            TargetId = request.TargetId is not null ? new String { Value = request.TargetId } : null
        };

        var result =
            await loadData.client.DeleteAsync(payload, cancellationToken: cancellationToken, headers: loadData.headers);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new DeleteResponseBody { ArticleCommentAnswerId = result.Body.AnswerId }
        };
    }

    public void Dispose()
    {
        _channel.Dispose();
    }
    
    /*---------------------------------------------------------------*/

    private async Task<(Metadata headers, ArticleCommentAnswerService.ArticleCommentAnswerServiceClient client)> 
        _loadGrpcChannelAsync(CancellationToken cancellationToken)
    {
        var targetServiceInstance =
            await _serviceDiscovery.LoadAddressInMemoryAsync(Service.CommentService, cancellationToken);
        
        _channel = GrpcChannel.ForAddress(targetServiceInstance, new GrpcChannelOptions().GetAll());

        return (
            new() {
                { Header.Token   , _httpContextAccessor.HttpContext.GetRowToken() },
                { Header.License , _configuration.GetValue<string>("SecretKey") }
            },
            new ArticleCommentAnswerService.ArticleCommentAnswerServiceClient(_channel)
        );
    }
}