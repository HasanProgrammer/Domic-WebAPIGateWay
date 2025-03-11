using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.TicketUseCase.DTOs.GRPCs.CreateComment;

namespace Domic.UseCase.TicketUseCase.Commands.CreateComment;

public class CreateCommentCommand : ICommand<CreateCommentResponse>
{
    public required string TicketId { get; set; }
    public required string Comment { get; set; }
}