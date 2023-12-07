using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.ArticleUseCase.DTOs.GRPCs.Create;
using Microsoft.AspNetCore.Http;

namespace Karami.UseCase.ArticleUseCase.Commands.Create;

public class CreateCommand : ICommand<CreateResponse>
{
    public string UserId         { get; set; }
    public string CategoryId     { get; set; }
    public string Title          { get; set; }
    public string Summary        { get; set; }
    public string Body           { get; set; }
    public IFormFile Image       { get; set; }
    public string ImagePath      { get; set; }
    public string ImageName      { get; set; }
    public string ImageExtension { get; set; }
}