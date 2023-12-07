using Karami.Core.Common.ClassHelpers;
using Karami.UseCase.UserUseCase.DTOs.ViewModels;

namespace Karami.UseCase.UserUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponseBody
{
    public PaginatedCollection<UsersViewModel> Users { get; set; }
}