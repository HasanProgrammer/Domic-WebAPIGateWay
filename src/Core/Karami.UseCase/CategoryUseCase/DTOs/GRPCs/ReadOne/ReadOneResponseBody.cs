using Karami.UseCase.CategoryUseCase.DTOs.ViewModels;

namespace Karami.UseCase.CategoryUseCase.DTOs.GRPCs.ReadOne;

public class ReadOneResponseBody
{
    public CategoriesViewModel Category { get; set; }
}