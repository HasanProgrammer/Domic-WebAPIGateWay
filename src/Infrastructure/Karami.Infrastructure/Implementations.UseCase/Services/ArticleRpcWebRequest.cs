using Grpc.Core;
using Grpc.Net.Client;
using Karami.Core.Common.ClassConsts;
using Karami.Core.Common.ClassHelpers;
using Karami.Core.Grpc.Article;
using Karami.Core.Infrastructure.Extensions;
using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.Infrastructure.Extensions;
using Karami.UseCase.ArticleUseCase.Commands.Active;
using Karami.UseCase.ArticleUseCase.Commands.Create;
using Karami.UseCase.ArticleUseCase.Commands.Delete;
using Karami.UseCase.ArticleUseCase.Commands.InActive;
using Karami.UseCase.ArticleUseCase.Commands.Update;
using Karami.UseCase.ArticleUseCase.DTOs.ViewModels;
using Karami.UseCase.ArticleUseCase.Queries.ReadAllPaginated;
using Karami.UseCase.ArticleUseCase.Queries.ReadOne;
using Karami.UseCase.RoleUseCase.Contracts.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

using String                       = Karami.Core.Grpc.Article.String;
using Int32                        = Karami.Core.Grpc.Article.Int32;
using CreateResponse               = Karami.UseCase.ArticleUseCase.DTOs.GRPCs.Create.CreateResponse;
using CreateResponseBody           = Karami.UseCase.ArticleUseCase.DTOs.GRPCs.Create.CreateResponseBody;
using UpdateResponse               = Karami.UseCase.ArticleUseCase.DTOs.GRPCs.Update.UpdateResponse;
using UpdateResponseBody           = Karami.UseCase.ArticleUseCase.DTOs.GRPCs.Update.UpdateResponseBody;
using DeleteResponse               = Karami.UseCase.ArticleUseCase.DTOs.GRPCs.Delete.DeleteResponse;
using DeleteResponseBody           = Karami.UseCase.ArticleUseCase.DTOs.GRPCs.Delete.DeleteResponseBody;
using ReadAllPaginatedResponse     = Karami.UseCase.ArticleUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponse;
using ReadAllPaginatedResponseBody = Karami.UseCase.ArticleUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponseBody;
using ReadOneResponse              = Karami.UseCase.ArticleUseCase.DTOs.GRPCs.ReadOne.ReadOneResponse;
using ReadOneResponseBody          = Karami.UseCase.ArticleUseCase.DTOs.GRPCs.ReadOne.ReadOneResponseBody;
using ActiveResponse               = Karami.UseCase.ArticleUseCase.DTOs.GRPCs.Active.ActiveResponse;
using ActiveResponseBody           = Karami.UseCase.ArticleUseCase.DTOs.GRPCs.Active.ActiveResponseBody;
using InActiveResponse             = Karami.UseCase.ArticleUseCase.DTOs.GRPCs.InActive.InActiveResponse;
using InActiveResponseBody         = Karami.UseCase.ArticleUseCase.DTOs.GRPCs.InActive.InActiveResponseBody;

namespace Karami.Infrastructure.Implementations.UseCase.Services;

public class ArticleRpcWebRequest : IArticleRpcWebRequest
{
    private readonly IServiceDiscovery    _serviceDiscovery;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IConfiguration       _configuration;
    
    private GrpcChannel _channel;

    public ArticleRpcWebRequest(IConfiguration configuration, IHttpContextAccessor httpContextAccessor,
        IServiceDiscovery serviceDiscovery
    )
    {
        _configuration       = configuration;
        _httpContextAccessor = httpContextAccessor;
        _serviceDiscovery    = serviceDiscovery;
    }

    public async Task<bool> CheckExistAsync(string id, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(cancellationToken);
        
        CheckExistRequest payload = new();

        payload.TargetId = id is not null ? new String { Value = id } : null;

        var result = 
            await loadData.client.CheckExistAsync(payload, headers: loadData.headers, 
                cancellationToken: cancellationToken
            );

        return result.Result;
    }

    public async Task<ReadOneResponse> ReadOneAsync(ReadOneQuery request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(cancellationToken);
        
        ReadOneRequest payload = new() {
            TargetId = !string.IsNullOrEmpty(request.TargetId) ? new String { Value = request.TargetId } : null
        };

        var result = 
            await loadData.client.ReadOneAsync(payload, headers: loadData.headers, 
                cancellationToken: cancellationToken
            );
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ReadOneResponseBody {
                Article = result.Body.Article.DeSerialize<ArticlesViewModel>()
            }
        };
    }

    public async Task<ReadAllPaginatedResponse> ReadAllPaginatedAsync(ReadAllPaginatedQuery request, 
        CancellationToken cancellationToken
    )
    {
        var loadData = await _loadGrpcChannelAsync(cancellationToken);
        
        ReadAllPaginatedRequest payload = new() {
            PageNumber   = request.PageNumber   != null ? new Int32 { Value = (int)request.PageNumber }   : null ,
            CountPerPage = request.CountPerPage != null ? new Int32 { Value = (int)request.CountPerPage } : null
        };

        var result = 
            await loadData.client.ReadAllPaginatedAsync(payload, headers: loadData.headers, 
                cancellationToken: cancellationToken
            );
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ReadAllPaginatedResponseBody {
                Articles = result.Body.Articles.DeSerialize<PaginatedCollection<ArticlesViewModel>>()
            }
        };
    }

    public async Task<CreateResponse> CreateAsync(CreateCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(cancellationToken);
        
        CreateRequest payload = new();
        
        payload.UserId     = request.UserId     != null ? new String { Value = request.UserId }     : null;
        payload.CategoryId = request.CategoryId != null ? new String { Value = request.CategoryId } : null;
        payload.Title      = request.Title      != null ? new String { Value = request.Title }      : null;
        payload.Summary    = request.Summary    != null ? new String { Value = request.Summary }    : null;
        payload.Body       = request.Body       != null ? new String { Value = request.Body }       : null;
        
        payload.Image = new Image {
            Path      = request.ImagePath      != null ? new String { Value = request.ImagePath }      : null,
            Name      = request.ImageName      != null ? new String { Value = request.ImageName }      : null,
            Extension = request.ImageExtension != null ? new String { Value = request.ImageExtension } : null
        };

        var result = 
            await loadData.client.CreateAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new CreateResponseBody { ArticleId = result.Body.ArticleId }
        };
    }

    public async Task<UpdateResponse> UpdateAsync(UpdateCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(cancellationToken);
        
        UpdateRequest payload = new();
        
        payload.TargetId   = request.TargetId   != null ? new String { Value = request.TargetId }   : null;
        payload.CategoryId = request.CategoryId != null ? new String { Value = request.CategoryId } : null;
        payload.Title      = request.Title      != null ? new String { Value = request.Title }      : null;
        payload.Summary    = request.Summary    != null ? new String { Value = request.Summary }    : null;
        payload.Body       = request.Body       != null ? new String { Value = request.Body }       : null;
        
        payload.Image = request.Image is not null ? new Image {
            Path      = request.ImagePath      != null ? new String { Value = request.ImagePath }      : null,
            Name      = request.ImageName      != null ? new String { Value = request.ImageName }      : null,
            Extension = request.ImageExtension != null ? new String { Value = request.ImageExtension } : null
        } : null;

        var result = 
            await loadData.client.UpdateAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);
     
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new UpdateResponseBody { ArticleId = result.Body.ArticleId }
        };
    }

    public async Task<ActiveResponse> ActiveAsync(ActiveCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(cancellationToken);
        
        ActiveRequest payload = new();

        payload.TargetId = request.TargetId != null ? new String { Value = request.TargetId } : null;

        var result = 
            await loadData.client.ActiveAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);

        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ActiveResponseBody { ArticleId = result.Body.ArticleId }
        };
    }

    public async Task<InActiveResponse> InActiveAsync(InActiveCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(cancellationToken);
        
        InActiveRequest payload = new();

        payload.TargetId = request.TargetId != null ? new String { Value = request.TargetId } : null;

        var result = 
            await loadData.client.InActiveAsync(payload, headers: loadData.headers, 
                cancellationToken: cancellationToken
            );

        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new InActiveResponseBody { ArticleId = result.Body.ArticleId }
        };
    }

    public async Task<DeleteResponse> DeleteAsync(DeleteCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(cancellationToken);
        
        DeleteRequest payload = new() {
            TargetId = !string.IsNullOrEmpty(request.TargetId) ? new String { Value = request.TargetId } : null
        };

        var result = 
            await loadData.client.DeleteAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new DeleteResponseBody { ArticleId = result.Body.ArticleId }
        };
    }

    public void Dispose()
    {
        _channel.Dispose();
    }
    
    /*---------------------------------------------------------------*/

    private async Task<(Metadata headers, ArticleService.ArticleServiceClient client)> 
        _loadGrpcChannelAsync(CancellationToken cancellationToken)
    {
        var targetServiceInstance =
            await _serviceDiscovery.LoadAddressInMemoryAsync(Service.ArticleService, cancellationToken);
        
        _channel = GrpcChannel.ForAddress(targetServiceInstance, new GrpcChannelOptions().GetAll());

        return (
            new() {
                { Header.Token   , _httpContextAccessor.HttpContext.GetRowToken() },
                { Header.License , _configuration.GetValue<string>("SecretKey") }
            },
            new ArticleService.ArticleServiceClient(_channel)
        );
    }
}