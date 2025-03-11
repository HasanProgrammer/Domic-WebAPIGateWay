using Domic.UseCase.Commons.DTOs.GRPCs;

namespace Domic.UseCase.TicketUseCase.DTOs.GRPCs.CreateComment;

public class CreateCommentResponse : BaseResponse
{
    public CreateCommentResponseBody Body { get; set; }
}