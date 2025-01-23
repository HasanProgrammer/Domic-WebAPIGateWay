using Domic.UseCase.UserUseCase.DTOs.GRPCs.ReadAllPaginated;
using Domic.Core.UseCase.Contracts.Abstracts;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.UserUseCase.Queries.ReadAllPaginated;

public class ReadAllPaginatedQuery : PaginatedQuery, IQuery<ReadAllPaginatedResponse>
{
    public string FirstName   { get; set; }
    public string LastName    { get; set; }
    public string Username    { get; set; }
    public string PhoneNumber { get; set; }
    public string Email       { get; set; }
}