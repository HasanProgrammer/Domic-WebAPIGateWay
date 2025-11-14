using Domic.Core.Common.ClassHelpers;

namespace Domic.UseCase.AnnouncementUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponseBody
{
    public PaginatedCollection<AnnouncementDto> Announcements { get; set; }
}