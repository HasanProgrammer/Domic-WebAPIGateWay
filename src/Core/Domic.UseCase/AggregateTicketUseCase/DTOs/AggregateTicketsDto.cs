namespace Domic.UseCase.AggregateTicketUseCase.DTOs;

public class TicketCommentDto
{
    public required string Id { get; init; }
    public required string Comment { get; init; }
    public required string OwnerFirstName { get; init; }
    public required string OwnerLastName { get; init; }
}

public class AggregateTicketsDto
{
    //ticket
    public required string Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required int Status { get; set; }
    public required string StatusTitle { get; set; }
    public required int Priority { get; set; }
    public required string PriorityTitle { get; set; }
    
    //comment
    public List<TicketCommentDto> Comments { get; init; }
    
    //user
    public required string Username { get; init; }
    public required string Author { get; set; }
    
    //category
    public required string CategoryName { get; init; }
    
    public required DateTime EnCreatedAt { get; set; }
    public required string FrCreatedAt { get; set; }
}