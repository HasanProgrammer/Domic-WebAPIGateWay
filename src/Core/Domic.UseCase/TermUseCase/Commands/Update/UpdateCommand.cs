using Domic.UseCase.TermUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Commons.Enumerations;
using Microsoft.AspNetCore.Http;

namespace Domic.UseCase.TermUseCase.Commands.Update;

public class UpdateCommand : ICommand<UpdateResponse>
{
    public required string TermId { get; set; }
    public required string CategoryId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string ImageUrl { get; set; }
    public required string Price { get; set; }
    public required TermStatus? Status { get; set; }
    
    #region File

    public IFormFile Image { get; set; }

    #endregion
}