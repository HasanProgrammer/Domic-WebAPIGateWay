using Domic.UseCase.CategoryUseCase.DTOs.ViewModels;

namespace Domic.UseCase.CategoryUseCase.DTOs.GRPCs.ReadOne;

public class ReadOneResponseBody
{
    public CategoryDto Category { get; set; }
}