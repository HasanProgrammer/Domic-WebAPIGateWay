using Domic.UseCase.ArticleUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Domic.UseCase.ArticleUseCase.Commands.Update;

public class UpdateCommand : ICommand<UpdateResponse>
{
    public string Id             { get; set; }
    public string CategoryId     { get; set; }
    public string Title          { get; set; }
    public string Summary        { get; set; }
    public string Body           { get; set; }
    public IFormFile Image       { get; set; }
    public string ImagePath      { get; set; }
    public string ImageName      { get; set; }
    public string ImageExtension { get; set; }
}