using Domic.UseCase.TermCommentUseCase.DTOs.GRPCs.Create;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.TermCommentUseCase.Commands.Create;

public class CreateCommand : ICommand<CreateResponse>
{
    public string TermId  { get; set; }
    public string Comment { get; set; }
}