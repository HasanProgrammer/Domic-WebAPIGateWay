using Domic.Core.Common.ClassHelpers;

namespace Domic.UseCase.StackUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponseBody
{
    public PaginatedCollection<StackDto> Stacks { get; set; }
}