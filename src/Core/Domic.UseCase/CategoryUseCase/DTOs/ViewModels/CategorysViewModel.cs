using Domic.Core.UseCase.DTOs.ViewModels;

namespace Domic.UseCase.CategoryUseCase.DTOs.ViewModels;

public class CategoriesViewModel : ViewModel
{
    public string Id   { get; set; }
    public string Name { get; set; }
}