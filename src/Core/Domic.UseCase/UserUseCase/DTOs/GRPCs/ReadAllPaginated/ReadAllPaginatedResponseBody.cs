using Domic.Core.Common.ClassHelpers;

namespace Domic.UseCase.UserUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponseBody
{
    public PaginatedCollection<UserDto> Users { get; set; }
}