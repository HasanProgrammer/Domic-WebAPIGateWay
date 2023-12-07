using Karami.Core.Common.ClassHelpers;
using Karami.UseCase.CategoryUseCase.DTOs.ViewModels;

namespace Karami.UseCase.CategoryUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponseBody
{
    public PaginatedCollection<CategoriesViewModel> Categories { get; set; }
}