using Domic.Core.Common.ClassHelpers;
using Domic.UseCase.VideoUseCase.DTOs;

namespace Domic.UseCase.VideoUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponseBody
{
    public PaginatedCollection<VideoDto> Videos { get; set; }
}