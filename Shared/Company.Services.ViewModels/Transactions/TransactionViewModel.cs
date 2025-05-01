namespace Company.Services.ViewModels.Transactions;

public record TransactionViewModel
{
    public Guid TransactionExternalId { get; set; }
    public DateTime CreatedAt { get; set; }
}