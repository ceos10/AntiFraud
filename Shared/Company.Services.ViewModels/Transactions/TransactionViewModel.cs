using Company.Services.ViewModels.Transactions.Enums;

namespace Company.Services.ViewModels.Transactions;

public record TransactionViewModel
{
    public Guid TransactionExternalId { get; set; }
    public DateTime CreatedAt { get; set; }
    public TransactionStatusViewModel Status { get; set; } //Added to validate status in GetTransactionById
}