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
    public required string Id { get; init; }
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required int Priority { get; init; }
    public required int Status { get; init; }
    
    //comment
    public List<TicketCommentDto> Comments { get; init; }
    
    //user
    public required string Username { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    
    //category
    public required string CategoryName { get; init; }
}