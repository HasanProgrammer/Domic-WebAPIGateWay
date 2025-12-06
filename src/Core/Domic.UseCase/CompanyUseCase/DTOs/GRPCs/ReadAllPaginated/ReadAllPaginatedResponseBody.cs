using Domic.Core.Common.ClassHelpers;

namespace Domic.UseCase.CompanyUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponseBody
{
    public PaginatedCollection<CompanyDto> Companies { get; set; }
}