namespace Company.Services.ViewModels.Transactions;

public record TransactionAntiFraudViewModel
{
    public Guid TransactionExternalId { get; set; }
    public decimal Value { get; set; }
}
