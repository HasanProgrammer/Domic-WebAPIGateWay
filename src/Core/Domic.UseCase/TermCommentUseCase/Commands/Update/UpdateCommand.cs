using Domic.UseCase.TermCommentUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.TermCommentUseCase.Commands.Update;

public class UpdateCommand : ICommand<UpdateResponse>
{
    public required string Id { get; set; }
    public required string Comment  { get; set; }
}