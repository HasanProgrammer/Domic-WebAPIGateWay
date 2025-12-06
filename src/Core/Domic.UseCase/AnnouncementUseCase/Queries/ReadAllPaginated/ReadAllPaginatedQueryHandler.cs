using Domic.UseCase.AnnouncementUseCase.DTOs.GRPCs.ReadAllPaginated;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.AnnouncementUseCase.Contracts.Interfaces;

namespace Domic.UseCase.AnnouncementUseCase.Queries.ReadAllPaginated;

public class ReadAllPaginatedQueryHandler(IAnnouncementRpcWebRequest announcementRpcWebRequest) 
    : IQueryHandler<ReadAllPaginatedQuery, ReadAllPaginatedResponse>
{
    [WithValidation]
    public Task<ReadAllPaginatedResponse> HandleAsync(ReadAllPaginatedQuery query, CancellationToken cancellationToken) 
        => announcementRpcWebRequest.ReadAllPaginatedAsync(query, cancellationToken);
}