using Domic.UseCase.AnnouncementUseCase.DTOs.GRPCs.ReadOne;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.AnnouncementUseCase.Contracts.Interfaces;

namespace Domic.UseCase.AnnouncementUseCase.Queries.ReadOne;

public class ReadOneQueryHandler(IAnnouncementRpcWebRequest announcementRpcWebRequest) : IQueryHandler<ReadOneQuery, ReadOneResponse>
{
    public Task<ReadOneResponse> HandleAsync(ReadOneQuery query, CancellationToken cancellationToken) 
        => announcementRpcWebRequest.ReadOneAsync(query, cancellationToken);
}