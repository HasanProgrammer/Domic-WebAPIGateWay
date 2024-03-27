using Domic.Core.Common.ClassHelpers;
using Domic.UseCase.VideoUseCase.DTOs.ViewModels;

namespace Domic.UseCase.VideoUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponseBody
{
    public PaginatedCollection<VideosDto> Terms { get; set; }
}