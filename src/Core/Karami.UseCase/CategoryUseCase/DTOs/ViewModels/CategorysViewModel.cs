using Karami.Core.UseCase.DTOs.ViewModels;

namespace Karami.UseCase.CategoryUseCase.DTOs.ViewModels;

public class CategoriesViewModel : ViewModel
{
    public string Id   { get; set; }
    public string Name { get; set; }
}