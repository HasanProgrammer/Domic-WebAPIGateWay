using Grpc.Core;
using Grpc.Net.Client;
using Domic.Core.Common.ClassConsts;
using Domic.Core.Common.ClassHelpers;
using Domic.Core.Article.Grpc;
using Domic.Core.Category.Grpc;
using Domic.Core.Infrastructure.Extensions;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Infrastructure.Extensions;
using Domic.UseCase.CategoryUseCase.Commands.Create;
using Domic.UseCase.CategoryUseCase.Commands.Delete;
using Domic.UseCase.CategoryUseCase.Commands.Update;
using Domic.UseCase.CategoryUseCase.DTOs.ViewModels;
using Domic.UseCase.CategoryUseCase.Queries.ReadAllPaginated;
using Domic.UseCase.CategoryUseCase.Queries.ReadOne;
using Domic.UseCase.RoleUseCase.Contracts.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

using CheckExistRequest            = Domic.Core.Category.Grpc.CheckExistRequest;
using CreateRequest                = Domic.Core.Category.Grpc.CreateRequest;
using String                       = Domic.Core.Category.Grpc.String;
using Int32                        = Domic.Core.Category.Grpc.Int32;
using CreateResponse               = Domic.UseCase.CategoryUseCase.DTOs.GRPCs.Create.CreateResponse;
using CreateResponseBody           = Domic.UseCase.CategoryUseCase.DTOs.GRPCs.Create.CreateResponseBody;
using DeleteRequest                = Domic.Core.Category.Grpc.DeleteRequest;
using DeleteResponse               = Domic.UseCase.CategoryUseCase.DTOs.GRPCs.Delete.DeleteResponse;
using DeleteResponseBody           = Domic.UseCase.CategoryUseCase.DTOs.GRPCs.Delete.DeleteResponseBody;
using ReadAllPaginatedRequest      = Domic.Core.Category.Grpc.ReadAllPaginatedRequest;
using ReadAllPaginatedResponse     = Domic.UseCase.CategoryUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponse;
using ReadAllPaginatedResponseBody = Domic.UseCase.CategoryUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponseBody;
using ReadOneRequest               = Domic.Core.Category.Grpc.ReadOneRequest;
using ReadOneResponse              = Domic.UseCase.CategoryUseCase.DTOs.GRPCs.ReadOne.ReadOneResponse;
using ReadOneResponseBody          = Domic.UseCase.CategoryUseCase.DTOs.GRPCs.ReadOne.ReadOneResponseBody;
using UpdateRequest                = Domic.Core.Category.Grpc.UpdateRequest;
using UpdateResponse               = Domic.UseCase.CategoryUseCase.DTOs.GRPCs.Update.UpdateResponse;
using UpdateResponseBody           = Domic.UseCase.CategoryUseCase.DTOs.GRPCs.Update.UpdateResponseBody;

namespace Domic.Infrastructure.Implementations.UseCase.Services;

public class CategoryRpcWebRequest : ICategoryRpcWebRequest
{
    private readonly IServiceDiscovery    _serviceDiscovery;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IConfiguration       _configuration;
    
    private GrpcChannel _channel;

    public CategoryRpcWebRequest(IConfiguration configuration, IHttpContextAccessor httpContextAccessor,
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
            await loadData.client.CheckExistAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);

        return result.Result;
    }

    public async Task<ReadOneResponse> ReadOneAsync(ReadOneQuery request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(cancellationToken);
        
        ReadOneRequest payload = new() {
            TargetId = request.CategoryId != null ? new String { Value = request.CategoryId } : null
        };

        var result = 
            await loadData.client.ReadOneAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ReadOneResponseBody { Category = result.Body.Category.DeSerialize<CategoriesViewModel>() } 
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
                Categories = result.Body.Categories.DeSerialize<PaginatedCollection<CategoriesViewModel>>()
            } 
        };
    }

    public async Task<CreateResponse> CreateAsync(CreateCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(cancellationToken);
        
        CreateRequest payload = new();
        
        payload.Name = request.Name != null ? new String { Value = request.Name } : null;
        
        var result = 
            await loadData.client.CreateAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new CreateResponseBody { CategoryId = result.Body.CategoryId }
        };
    }

    public async Task<UpdateResponse> UpdateAsync(UpdateCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(cancellationToken);
        
        UpdateRequest payload = new() {
            TargetId = request.Id   is not null ? new String { Value = request.Id }   : null ,
            Name     = request.Name is not null ? new String { Value = request.Name } : null
        };

        var result = 
            await loadData.client.UpdateAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new UpdateResponseBody { CategoryId = result.Body.CategoryId }
        };
    }

    public async Task<DeleteResponse> DeleteAsync(DeleteCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(cancellationToken);
        
        DeleteRequest payload = new() {
            TargetId = request.CategoryId is not null ? new String { Value = request.CategoryId } : null
        };

        var result = 
            await loadData.client.DeleteAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new DeleteResponseBody { CategoryId = result.Body.CategoryId }
        };
    }

    public void Dispose()
    {
        _channel.Dispose();
    }
    
    /*---------------------------------------------------------------*/

    private async Task<(Metadata headers, CategoryService.CategoryServiceClient client)> 
        _loadGrpcChannelAsync(CancellationToken cancellationToken)
    {
        var targetServiceInstance =
            await _serviceDiscovery.LoadAddressInMemoryAsync(Service.CategoryService, cancellationToken);
        
        _channel = GrpcChannel.ForAddress(targetServiceInstance, new GrpcChannelOptions().GetAll());

        return (
            new() {
                { Header.Token   , _httpContextAccessor.HttpContext.GetRowToken() },
                { Header.License , _configuration.GetValue<string>("SecretKey") }
            },
            new CategoryService.CategoryServiceClient(_channel)
        );
    }
}