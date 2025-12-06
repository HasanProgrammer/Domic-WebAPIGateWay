namespace Domic.UseCase.FinancialUseCase.DTOs.GRPCs.ReadAllTransactionPaginated;

public class TransactionDto
{
    public string Id { get; set; }
    public string Owner { get; set; }
    public string Type { get; set; }
    public long Amount { get; set; }
    public DateTime EnCreatedAt { get; set; }
    public string FrCreatedAt { get; set; }
    public bool IsActive { get; set; }
}