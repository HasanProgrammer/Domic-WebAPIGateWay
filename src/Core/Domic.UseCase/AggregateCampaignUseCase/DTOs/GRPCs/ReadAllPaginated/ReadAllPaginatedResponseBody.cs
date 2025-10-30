using Domic.Core.Common.ClassHelpers;

namespace Domic.UseCase.AggregateCampaignUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponseBody
{
    public PaginatedCollection<AggregateCampaignDto> Campaigns { get; set; }
}