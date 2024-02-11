using Domic.UseCase.UserUseCase.DTOs.ViewModels;
using Domic.Core.Common.ClassHelpers;

namespace Domic.UseCase.UserUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponseBody
{
    public PaginatedCollection<UsersViewModel> Users { get; set; }
}